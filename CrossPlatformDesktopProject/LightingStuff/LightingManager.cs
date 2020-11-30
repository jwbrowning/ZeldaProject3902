using CrossPlatformDesktopProject.Environment;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.LightingStuff
{
    public class LightingManager
    {
        class LineSegment
        {
            public Vector2 A { get; set; }
            public Vector2 B { get; set; }
            public LineSegment(Vector2 a, Vector2 b)
            {
                A = a;
                B = b;
            }
        }

        class Ray
        {
            public Vector2 Point { get; set; }
            public Vector2 Direction { get; set; }
            public float Angle
            {
                get
                {
                    return StandardAngle((float)Math.Atan2(Direction.Y, Direction.X));
                }
                set
                {
                    Direction = new Vector2((float)Math.Cos(StandardAngle(value)), (float)Math.Sin(StandardAngle(value)));
                    Direction.Normalize();
                }
            }
            public Ray(Vector2 point, Vector2 direction)
            {
                Point = point;
                Direction = direction;
                Direction.Normalize();
            }
        }

        class RaycastPoint
        {
            public Vector2 Point { get; set; }
            public float Angle { get; set; }
            public RaycastPoint(Vector2 point, float angle)
            {
                Point = point;
                Angle = StandardAngle(angle);
            }
        }

        class RaycastPointCompare : IComparer<RaycastPoint>
        {
            public RaycastPointCompare()
            {

            }

            public int Compare(RaycastPoint a, RaycastPoint b)
            {
                return a.Angle.CompareTo(b.Angle);
            }
        }

        private Game1 game;
        private Vector2 prevPlayerPos;
        private Vector2 blockSize = new Vector2(65, 65);
        private List<RaycastPoint> visibleRegion;
        private Microsoft.Xna.Framework.Color shadowColor = new Microsoft.Xna.Framework.Color(0, 0, 0, .5f);
        private Texture2D lightingTexture;

        public static object TextureUsage { get; private set; }

        public LightingManager(Game1 game)
        {
            this.game = game;
            prevPlayerPos = Vector2.Zero;
            visibleRegion = VisibleRegion(game.player.Position + game.currentRoom.Position);
            //lightingTexture = game.Content.Load<Texture2D>("VisibilityRectangle2");
        }

        public void Update()
        {
            //if (game.player.Position != prevPlayerPos) 
            visibleRegion = VisibleRegion(game.player.Position + game.currentRoom.Position);

            //prevPlayerPos = game.player.Position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawVisibleRegion(spriteBatch, visibleRegion);
        }

        private List<RaycastPoint> VisibleRegion(Vector2 sourcePoint)
        {
            List<Vector2> wallCorners = GetWallCorners();
            List<LineSegment> wallLineSegments = GetWallLineSegments();
            List<RaycastPoint> closestIntersections = new List<RaycastPoint>();

            foreach (Vector2 corner in wallCorners)
            {
                Ray ray = new Ray(sourcePoint, corner - sourcePoint);
                Ray ray1 = new Ray(sourcePoint, corner - sourcePoint);
                ray1.Angle += .00001f;
                Ray ray2 = new Ray(sourcePoint, corner - sourcePoint);
                ray2.Angle -= .00001f;
                Vector2 closestIntersect = new Vector2(float.MaxValue, float.MaxValue);
                Vector2 closestIntersect1 = new Vector2(float.MaxValue, float.MaxValue);
                Vector2 closestIntersect2 = new Vector2(float.MaxValue, float.MaxValue);
                foreach (LineSegment lineSegment in wallLineSegments)
                {
                    Vector2 intersect = Intersection(ray, lineSegment);
                    Vector2 intersect1 = Intersection(ray1, lineSegment);
                    Vector2 intersect2 = Intersection(ray2, lineSegment);
                    if (intersect != sourcePoint && Vector2.Distance(sourcePoint, intersect) < Vector2.Distance(sourcePoint, closestIntersect))
                    {
                        closestIntersect = intersect;
                    }
                    if (intersect1 != sourcePoint && Vector2.Distance(sourcePoint, intersect1) < Vector2.Distance(sourcePoint, closestIntersect1))
                    {
                        closestIntersect1 = intersect1;
                    }
                    if (intersect2 != sourcePoint && Vector2.Distance(sourcePoint, intersect2) < Vector2.Distance(sourcePoint, closestIntersect2))
                    {
                        closestIntersect2 = intersect2;
                    }
                }
                closestIntersections.Add(new RaycastPoint(closestIntersect, ray.Angle));
                closestIntersections.Add(new RaycastPoint(closestIntersect1, ray1.Angle));
                closestIntersections.Add(new RaycastPoint(closestIntersect2, ray2.Angle));
            }

            closestIntersections.Sort(new RaycastPointCompare());

            return closestIntersections;
        }

        // returns intersection if it exists, else returns ray's source point
        private Vector2 Intersection(Ray ray, LineSegment lineSegment)
        {
            // check if parallel:
            Vector2 lineSegmentDirection = lineSegment.B - lineSegment.A;
            Vector2 lineSegmentDirection2 = lineSegment.A - lineSegment.B;
            float xMult = lineSegmentDirection.X / ray.Direction.X;
            float yMult = lineSegmentDirection.Y / ray.Direction.Y;
            float xMult2 = lineSegmentDirection2.X / ray.Direction.X;
            float yMult2 = lineSegmentDirection2.Y / ray.Direction.Y;
            if (xMult == yMult && xMult2 == yMult2) return ray.Point;

            float raySlope = ray.Direction.Y / ray.Direction.X;

            Vector2 intersection;
            if (lineSegmentDirection.X == 0)
            {
                intersection = new Vector2(lineSegment.A.X, raySlope * (lineSegment.A.X - ray.Point.X) + ray.Point.Y);
            } 
            else
            {
                intersection = new Vector2((lineSegment.A.Y - ray.Point.Y) / raySlope + ray.Point.X, lineSegment.A.Y);
            }

            // check if intersection is on the line segment
            Vector2 intersectionDirection = intersection - ray.Point;
            xMult = intersectionDirection.X / ray.Direction.X;
            yMult = intersectionDirection.Y / ray.Direction.Y;
            if (intersection.X >= Math.Min(lineSegment.A.X,lineSegment.B.X) && intersection.X <= Math.Max(lineSegment.A.X, lineSegment.B.X)
                && intersection.Y >= Math.Min(lineSegment.A.Y, lineSegment.B.Y) && intersection.Y <= Math.Max(lineSegment.A.Y, lineSegment.B.Y)
                && xMult - yMult < .01f && xMult > 0 && yMult > 0)
            {
                return intersection;
            }
            else
            {
                return ray.Point;
            }
        }

        private List<LineSegment> GetWallLineSegments()
        {
            List<LineSegment> lineSegments = new List<LineSegment>();

            // add walls:
            Vector2 topLeft = game.currentRoom.Position - game.currentRoom.Size / 2f;
            Vector2 bottomRight = game.currentRoom.Position + game.currentRoom.Size / 2f;
            Vector2 bottomLeft = new Vector2(game.currentRoom.Position.X - game.currentRoom.Size.X / 2f, game.currentRoom.Position.Y + game.currentRoom.Size.Y / 2f);
            Vector2 topRight = new Vector2(game.currentRoom.Position.X + game.currentRoom.Size.X / 2f, game.currentRoom.Position.Y - game.currentRoom.Size.Y / 2f);
            lineSegments.Add(new LineSegment(topLeft, topRight));
            lineSegments.Add(new LineSegment(topRight, bottomRight));
            lineSegments.Add(new LineSegment(bottomRight, bottomLeft));
            lineSegments.Add(new LineSegment(bottomLeft, topLeft));

            // add edges of each block:
            foreach (IBlock block in game.currentRoom.Blocks)
            {
                if (block is Stairs || block is StairsInvisible || block is BlockWater) continue;
                topLeft = new Vector2(block.Position.X + game.currentRoom.Position.X - blockSize.X / 2f, block.Position.Y + game.currentRoom.Position.Y - blockSize.Y / 2f);
                bottomLeft = new Vector2(block.Position.X + game.currentRoom.Position.X - blockSize.X / 2f, block.Position.Y + game.currentRoom.Position.Y + blockSize.Y / 2f);
                topRight = new Vector2(block.Position.X + game.currentRoom.Position.X + blockSize.X / 2f, block.Position.Y + game.currentRoom.Position.Y - blockSize.Y / 2f);
                bottomRight = new Vector2(block.Position.X + game.currentRoom.Position.X + blockSize.X / 2f, block.Position.Y + game.currentRoom.Position.Y + blockSize.Y / 2f);
                lineSegments.Add(new LineSegment(topLeft, topRight));
                lineSegments.Add(new LineSegment(topRight, bottomRight));
                lineSegments.Add(new LineSegment(bottomRight, bottomLeft));
                lineSegments.Add(new LineSegment(bottomLeft, topLeft));
            }

            return lineSegments;
        }

        private List<Vector2> GetWallCorners()
        {
            List<Vector2> corners = new List<Vector2>();

            // add corners of the room's walls:
            Vector2 topLeft = game.currentRoom.Position - game.currentRoom.Size / 2f;
            Vector2 bottomRight = game.currentRoom.Position + game.currentRoom.Size / 2f;
            Vector2 bottomLeft = new Vector2(game.currentRoom.Position.X - game.currentRoom.Size.X / 2f, game.currentRoom.Position.Y + game.currentRoom.Size.Y / 2f);
            Vector2 topRight = new Vector2(game.currentRoom.Position.X + game.currentRoom.Size.X / 2f, game.currentRoom.Position.Y - game.currentRoom.Size.Y / 2f);
            corners.Add(topLeft);
            corners.Add(topRight);
            corners.Add(bottomRight);
            corners.Add(bottomLeft);

            // add corners of each block:
            foreach (IBlock block in game.currentRoom.Blocks)
            {
                if (block is Stairs || block is StairsInvisible) continue;
                topLeft = new Vector2(block.Position.X + game.currentRoom.Position.X - blockSize.X / 2f, block.Position.Y + game.currentRoom.Position.Y - blockSize.Y / 2f);
                bottomLeft = new Vector2(block.Position.X + game.currentRoom.Position.X - blockSize.X / 2f, block.Position.Y + game.currentRoom.Position.Y + blockSize.Y / 2f);
                topRight = new Vector2(block.Position.X + game.currentRoom.Position.X + blockSize.X / 2f, block.Position.Y + game.currentRoom.Position.Y - blockSize.Y / 2f);
                bottomRight = new Vector2(block.Position.X + game.currentRoom.Position.X + blockSize.X / 2f, block.Position.Y + game.currentRoom.Position.Y + blockSize.Y / 2f);
                corners.Add(topLeft);
                corners.Add(topRight);
                corners.Add(bottomRight);
                corners.Add(bottomLeft);
            }

            return corners;
        }

        private void DrawVisibleRegion(SpriteBatch spriteBatch, List<RaycastPoint> region)
        {
            spriteBatch.Begin();
            int pixelSize = 8;
            foreach (RaycastPoint rcp in region)
            {
                Rectangle destinationRectangle = new Rectangle((int)rcp.Point.X, (int)rcp.Point.Y, pixelSize, pixelSize);
                //spriteBatch.Draw(game.rect, destinationRectangle, new Color(1f * region.IndexOf(rcp) / region.Count, 0, 1 - 1f * region.IndexOf(rcp) / region.Count));
            }

            int startX = (int)(game.currentRoom.Position.X - game.currentRoom.Size.X / 2f);
            int startY = (int)(game.currentRoom.Position.Y - game.currentRoom.Size.Y / 2f);

            for (int i = startX; i < startX + game.currentRoom.Size.X; i += pixelSize)
            {
                for (int j = startY; j < startY + game.currentRoom.Size.Y; j += pixelSize)
                {
                    if (!InsideRegion(region, new Vector2(i + pixelSize / 2, j + pixelSize / 2)))
                    {
                        Rectangle destinationRectangle = new Rectangle(i, j, pixelSize, pixelSize);
                        spriteBatch.Draw(game.rect, destinationRectangle, shadowColor);
                    }
                    else
                    {
                        Rectangle destinationRectangle = new Rectangle(i, j, pixelSize, pixelSize);
                        spriteBatch.Draw(game.rect, destinationRectangle, new Color(.1f, .1f, 0, .05f));
                    }
                }
            }

            List<LineSegment> regionSegments = RegionLineSegments(visibleRegion);
            foreach(LineSegment lineSegment in regionSegments)
            {
                //DrawLineSegment(lineSegment, spriteBatch);
            }

            spriteBatch.End();


            /*for(int i=1;i<visibleRegion.Count;i++)
            {
                if (Vector2.Distance(visibleRegion[i].Point, visibleRegion[i - 1].Point) < 1f)
                {
                    visibleRegion.RemoveAt(i);
                    i--;
                }
            }*/

            BasicEffect basicEffect = new BasicEffect(game.GraphicsDevice);
            basicEffect.Texture = game.rect;
            basicEffect.TextureEnabled = true;

            VertexPositionTexture[] vert = new VertexPositionTexture[visibleRegion.Count];
            for(int i=0;i<visibleRegion.Count;i++)
            {
                vert[i].Position = new Vector3(visibleRegion[i].Point.X, visibleRegion[i].Point.Y, 0);
                vert[i].TextureCoordinate = new Vector2(0, 0);
            }

            foreach (EffectPass effectPass in basicEffect.CurrentTechnique.Passes)
            {
                effectPass.Apply();
                //game.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, vert, 0, vert.Length, new short[] { 0 }, 0,0);
            }
        }

        private void DrawLineSegment(LineSegment lineSegment, SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle((int)lineSegment.A.X, (int)lineSegment.A.Y, (int)Vector2.Distance(lineSegment.A, lineSegment.B), 4);
            Rectangle source = new Rectangle(0, 0, 1, 1);
            Vector2 direction = lineSegment.B - lineSegment.A;
            direction.Normalize();
            float angle = (float)Math.Atan2(direction.Y, direction.X);
            spriteBatch.Draw(game.rect, destination, source, Color.Yellow, angle, Vector2.Zero, SpriteEffects.None, 0);
        }

        public bool InsideVisibleRegion(Vector2 point)
        {
            return InsideRegion(visibleRegion, point);
        }

        private bool InsideRegion(List<RaycastPoint> region, Vector2 point)
        {
            if (region.Count < 3) return false;
            Vector2 source = game.player.Position + game.currentRoom.Position;
            Vector2 direction = point - source;
            direction.Normalize();
            float angle = (float)Math.Atan2(direction.Y, direction.X);
            int lower = region.IndexOf(region.FindLast((RaycastPoint rcp) => StandardAngle(rcp.Angle) < StandardAngle(angle)));
            if (lower == -1) lower = region.Count - 1;
            int upper = lower == region.Count - 1 ? 0 : lower + 1;

            double a1 = AreaOfTriangle(point, source, region[lower].Point);
            double a2 = AreaOfTriangle(point, region[lower].Point, region[upper].Point);
            double a3 = AreaOfTriangle(point, region[upper].Point, source);
            double total = AreaOfTriangle(source, region[lower].Point, region[upper].Point);
            return Math.Abs(total - (a1 + a2 + a3)) < .1f;

            /*Ray ray = new Ray(point, Vector2.UnitY);
            int intersectCount = 0;
            foreach (LineSegment lineSegment in triangleEdges)
            {
                if (Intersection(ray, lineSegment) != point)
                {
                    intersectCount++;
                }
            }
            return intersectCount % 2 != 0;*/
        }

        private double AreaOfTriangle(Vector2 v1, Vector2 v2, Vector2 v3)
        {
            return Math.Abs((v1.X * (v2.Y - v3.Y) +
                             v2.X * (v3.Y - v1.Y) +
                             v3.X * (v1.Y - v2.Y)) / 2d);
        }

        public static float StandardAngle(float angle)
        {
            while(angle >= 2 * Math.PI)
            {
                angle -= 2 * (float)Math.PI;
            }
            while (angle < 0)
            {
                angle += 2 * (float)Math.PI;
            }
            return angle;
        }

        private List<LineSegment> RegionLineSegments(List<RaycastPoint> region)
        {
            List<LineSegment> regionLineSegments = new List<LineSegment>();
            if (region.Count > 1) regionLineSegments.Add(new LineSegment(region[region.Count - 1].Point, region[0].Point));
            for (int i = 1; i < region.Count; i++)
            {
                regionLineSegments.Add(new LineSegment(region[i - 1].Point, region[i].Point));
            }
            return regionLineSegments;
        }

    }
}
