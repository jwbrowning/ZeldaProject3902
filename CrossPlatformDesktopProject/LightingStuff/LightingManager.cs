using CrossPlatformDesktopProject.Environment;
using CrossPlatformDesktopProject.RoomManagement;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
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
            public override bool Equals(object obj)
            {
                if (obj is LineSegment)
                {
                    LineSegment ls = ((LineSegment)obj);
                    return (ls.A == A && ls.B == B) || (ls.A == B && ls.B == A);
                }
                else
                {
                    return false;
                }
            }
            public override int GetHashCode()
            {
                throw new NotImplementedException();
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
        private Vector2 blockSize = new Vector2(64, 64);
        private List<RaycastPoint> visibleRegion;
        private Color shadowColor = new Color(0, 0, 0, .9f);
        private Color normalLightingColor = new Color(.15f, .15f, 0, .10f);
        private Color lightingColor;
        //private Texture2D lightingTexture;
        private float visionRadius = 2 * 64f;
        private float visionRadiusTarget = 2 * 64f;
        private float lerpSpeed = .025f;
        private float shadowSmoothLength = 2 * 64f;
        private float swordBeamLightRadius = 2 * 64f;
        private float swordBeamSmoothLength = 2 * 64f;
        private Vector2 swordBeamPos = Vector2.Zero;
        private bool litBySwordBeam = false;
        private bool litByPlayer = false;
        private int pixelSize = 16;
        private bool partyMode = false;
        private int partyTimer = 0;

        //Used for debugging
        const bool displayRays = false;
        const bool displayOutline = false;

        public LightingManager(Game1 game)
        {
            //normalLightingColor = new Color(1, 1, 1, 0);
            this.game = game;
            prevPlayerPos = Vector2.Zero;
            DisablePartyMode();
            visibleRegion = VisibleRegion(game.player.Position + game.currentRoom.Position);
            //lightingTexture = game.Content.Load<Texture2D>("VisibilityRectangle2");
            TurnOnLights();
        }

        public void TurnOnLights()
        {
            visionRadiusTarget = 12 * 64f;
            lerpSpeed = .01f;
        }

        public void TurnOffLights()
        {
            visionRadiusTarget = 2 * 64f;
            lerpSpeed = .025f;
        }

        public void EnablePartyMode()
        {
            partyMode = true;
        }

        public void DisablePartyMode()
        {
            partyMode = false;
            lightingColor = normalLightingColor;
        }

        public void Update()
        {
            if (partyMode)
            {
                int stage = partyTimer / 25;
                float c = .6f;
                float a = .4f;
                if (stage == 0)
                {
                    lightingColor = new Color(c, 0, 0, a);
                }
                else if (stage == 1)
                {
                    lightingColor = new Color(c, .5f * c, 0, a);
                }
                else if (stage == 2)
                {
                    lightingColor = new Color(0, c, 0, a);
                }
                else if (stage == 3)
                {
                    lightingColor = new Color(0, 0, c, a);
                }
                partyTimer++;
                if (partyTimer >= 100)
                {
                    partyTimer = 0;
                }
            }

            visionRadius += (visionRadiusTarget - visionRadius) * lerpSpeed;
            shadowSmoothLength = visionRadius;

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
                ray1.Angle += .001f;
                Ray ray2 = new Ray(sourcePoint, corner - sourcePoint);
                ray2.Angle -= .001f;
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
            if (intersection.X >= Math.Min(lineSegment.A.X, lineSegment.B.X) && intersection.X <= Math.Max(lineSegment.A.X, lineSegment.B.X)
                && intersection.Y >= Math.Min(lineSegment.A.Y, lineSegment.B.Y) && intersection.Y <= Math.Max(lineSegment.A.Y, lineSegment.B.Y)
                && xMult - yMult < .1f && xMult > 0 && yMult > 0)
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
            List<LineSegment> lineSegments = GetWallLineSegmentsFromRoom(game.currentRoom);

            if (game.currentRoom.nextRoom != null)
            {
                //lineSegments.AddRange(GetWallLineSegmentsFromRoom(game.currentRoom.nextRoom));
            }

            return lineSegments;
        }

        private List<LineSegment> GetWallLineSegmentsFromRoom(iRoom room)
        {
            List<LineSegment> lineSegments = new List<LineSegment>();

            // add walls:
            Vector2 topLeft = room.Position - room.Size / 2f;
            Vector2 bottomRight = room.Position + room.Size / 2f;
            Vector2 bottomLeft = new Vector2(room.Position.X - room.Size.X / 2f, room.Position.Y + room.Size.Y / 2f);
            Vector2 topRight = new Vector2(room.Position.X + room.Size.X / 2f, room.Position.Y - room.Size.Y / 2f);
            lineSegments.Add(new LineSegment(topLeft, topRight));
            lineSegments.Add(new LineSegment(topRight, bottomRight));
            lineSegments.Add(new LineSegment(bottomRight, bottomLeft));
            lineSegments.Add(new LineSegment(bottomLeft, topLeft));

            // add edges of each block:
            foreach (IBlock block in game.currentRoom.Blocks)
            {
                if (block is Stairs || block is StairsInvisible || block is BlockWater || block is BlockInvisible || block is Ladder) continue;
                topLeft = new Vector2(block.Position.X + room.Position.X - blockSize.X / 2f, block.Position.Y + room.Position.Y - blockSize.Y / 2f);
                bottomLeft = new Vector2(block.Position.X + room.Position.X - blockSize.X / 2f, block.Position.Y + room.Position.Y + blockSize.Y / 2f);
                topRight = new Vector2(block.Position.X + room.Position.X + blockSize.X / 2f, block.Position.Y + room.Position.Y - blockSize.Y / 2f);
                bottomRight = new Vector2(block.Position.X + room.Position.X + blockSize.X / 2f, block.Position.Y + room.Position.Y + blockSize.Y / 2f);
                LineSegment top = new LineSegment(topLeft, topRight);
                LineSegment right = new LineSegment(topRight, bottomRight);
                LineSegment bottom = new LineSegment(bottomRight, bottomLeft);
                LineSegment left = new LineSegment(bottomLeft, topLeft);
                if (Contains(lineSegments, top)) lineSegments.Remove(top);
                else lineSegments.Add(top);
                if (Contains(lineSegments, right)) lineSegments.Remove(right);
                else lineSegments.Add(right);
                if (Contains(lineSegments, bottom)) lineSegments.Remove(bottom);
                else lineSegments.Add(bottom);
                if (Contains(lineSegments, left)) lineSegments.Remove(left);
                else lineSegments.Add(left);
            }

            return lineSegments;
        }

        private List<Vector2> GetWallCorners()
        {
            List<Vector2> corners = GetWallCornersFromRoom(game.currentRoom);

            if (game.currentRoom.nextRoom != null)
            {
                //corners.AddRange(GetWallCornersFromRoom(game.currentRoom.nextRoom));
            }

            return corners;
        }

        private List<Vector2> GetWallCornersFromRoom(iRoom room)
        {
            List<Vector2> corners = new List<Vector2>();

            // add wall corners:
            Vector2 topLeft = room.Position - room.Size / 2f;
            Vector2 bottomRight = room.Position + room.Size / 2f;
            Vector2 bottomLeft = new Vector2(room.Position.X - room.Size.X / 2f, room.Position.Y + room.Size.Y / 2f);
            Vector2 topRight = new Vector2(room.Position.X + room.Size.X / 2f, room.Position.Y - room.Size.Y / 2f);
            corners.Add(topLeft);
            corners.Add(topRight);
            corners.Add(bottomRight);
            corners.Add(bottomLeft);

            // add corners of each block:
            foreach (IBlock block in game.currentRoom.Blocks)
            {
                if (block is Stairs || block is StairsInvisible || block is BlockWater || block is BlockInvisible || block is Ladder) continue;
                topLeft = new Vector2(block.Position.X + room.Position.X - blockSize.X / 2f, block.Position.Y + room.Position.Y - blockSize.Y / 2f);
                bottomLeft = new Vector2(block.Position.X + room.Position.X - blockSize.X / 2f, block.Position.Y + room.Position.Y + blockSize.Y / 2f);
                topRight = new Vector2(block.Position.X + room.Position.X + blockSize.X / 2f, block.Position.Y + room.Position.Y - blockSize.Y / 2f);
                bottomRight = new Vector2(block.Position.X + room.Position.X + blockSize.X / 2f, block.Position.Y + room.Position.Y + blockSize.Y / 2f);
                if (corners.Contains(topLeft)) corners.Remove(topLeft);
                else corners.Add(topLeft);
                if (corners.Contains(topRight)) corners.Remove(topRight);
                else corners.Add(topRight);
                if (corners.Contains(bottomRight)) corners.Remove(bottomRight);
                else corners.Add(bottomRight);
                if (corners.Contains(bottomLeft)) corners.Remove(bottomLeft);
                else corners.Add(bottomLeft);
            }

            return corners;
        }

        private bool Contains(List<LineSegment> list, LineSegment ls)
        {
            foreach (LineSegment l in list)
            {
                if (ls.Equals(l))
                {
                    return true;
                }
            }
            return false;
        }

        public void DrawDark(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            int startX = (int)(game.currentRoom.Position.X - game.currentRoom.Size.X / 2f);
            int startY = (int)(game.currentRoom.Position.Y - game.currentRoom.Size.Y / 2f);

            for (int i = startX; i < startX + game.currentRoom.Size.X; i += pixelSize)
            {
                for (int j = startY; j < startY + game.currentRoom.Size.Y; j += pixelSize)
                {
                    Rectangle destinationRectangle = new Rectangle(i, j, pixelSize, pixelSize);
                    spriteBatch.Draw(game.rect, destinationRectangle, shadowColor);
                }
            }

            if (game.currentRoom.nextRoom != null)
            {
                startX = (int)(game.currentRoom.nextRoom.Position.X - game.currentRoom.nextRoom.Size.X / 2f);
                startY = (int)(game.currentRoom.nextRoom.Position.Y - game.currentRoom.nextRoom.Size.Y / 2f);

                for (int i = startX; i < startX + game.currentRoom.nextRoom.Size.X; i += pixelSize)
                {
                    for (int j = startY; j < startY + game.currentRoom.nextRoom.Size.Y; j += pixelSize)
                    {
                        Rectangle destinationRectangle = new Rectangle(i, j, pixelSize, pixelSize);
                        spriteBatch.Draw(game.rect, destinationRectangle, shadowColor);
                    }
                }
            }

            spriteBatch.End();
        }

        private void DrawVisibleRegion(SpriteBatch spriteBatch, List<RaycastPoint> region)
        {
            Vector2 sourcePos = game.player.Position + game.currentRoom.Position;

            spriteBatch.Begin();

            int startX = (int)(game.currentRoom.Position.X - game.currentRoom.Size.X / 2f);
            int startY = (int)(game.currentRoom.Position.Y - game.currentRoom.Size.Y / 2f);

            for (int i = startX; i < startX + game.currentRoom.Size.X; i += pixelSize)
            {
                for (int j = startY; j < startY + game.currentRoom.Size.Y; j += pixelSize)
                {
                    Vector2 pixelPos = new Vector2(i + pixelSize / 2, j + pixelSize / 2);
                    Rectangle destinationRectangle = new Rectangle(i, j, pixelSize, pixelSize);
                    if (!InsideRegion(region, pixelPos))
                    {
                        spriteBatch.Draw(game.rect, destinationRectangle, shadowColor);
                    }
                    else if (litBySwordBeam && !litByPlayer)
                    {
                        if (Vector2.Distance(swordBeamPos, pixelPos) > swordBeamLightRadius - swordBeamSmoothLength)
                        {
                            float shadowWeight = (Vector2.Distance(swordBeamPos, pixelPos) - (swordBeamLightRadius - swordBeamSmoothLength)) / swordBeamSmoothLength;
                            float lightWeight = 1f - shadowWeight;
                            Color lightLevel = new Color(shadowWeight * shadowColor.R / 255f + lightWeight * lightingColor.R / 255f,
                                                         shadowWeight * shadowColor.G / 255f + lightWeight * lightingColor.G / 255f,
                                                         shadowWeight * shadowColor.B / 255f + lightWeight * lightingColor.B / 255f,
                                                         shadowWeight * shadowColor.A / 255f + lightWeight * lightingColor.A / 255f);
                            spriteBatch.Draw(game.rect, destinationRectangle, lightLevel);
                        }
                        else
                        {
                            spriteBatch.Draw(game.rect, destinationRectangle, lightingColor);
                        }
                    }
                    else if (litByPlayer && !litBySwordBeam)
                    {
                        if (Vector2.Distance(sourcePos, pixelPos) > visionRadius - shadowSmoothLength)
                        {
                            float shadowWeight = (Vector2.Distance(sourcePos, pixelPos) - (visionRadius - shadowSmoothLength)) / shadowSmoothLength;
                            float lightWeight = 1f - shadowWeight;
                            Color lightLevel = new Color(shadowWeight * shadowColor.R / 255f + lightWeight * lightingColor.R / 255f,
                                                         shadowWeight * shadowColor.G / 255f + lightWeight * lightingColor.G / 255f,
                                                         shadowWeight * shadowColor.B / 255f + lightWeight * lightingColor.B / 255f,
                                                         shadowWeight * shadowColor.A / 255f + lightWeight * lightingColor.A / 255f);
                            spriteBatch.Draw(game.rect, destinationRectangle, lightLevel);
                        }
                        else
                        {
                            spriteBatch.Draw(game.rect, destinationRectangle, lightingColor);
                        }
                    }
                    else if (litByPlayer && litBySwordBeam)
                    {
                        float playerLight = Vector2.Distance(sourcePos, pixelPos) - visionRadius + shadowSmoothLength;
                        float swordBeamLight = Vector2.Distance(swordBeamPos, pixelPos) - swordBeamLightRadius + swordBeamSmoothLength;
                        if (Math.Min(playerLight, swordBeamLight) > 0)
                        {
                            float shadowWeight1 = playerLight / shadowSmoothLength;
                            float shadowWeight2 = swordBeamLight / swordBeamSmoothLength;
                            float shadowWeight = Math.Min(shadowWeight1, shadowWeight2);
                            float lightWeight = 1f - shadowWeight;
                            Color lightLevel = new Color(shadowWeight * shadowColor.R / 255f + lightWeight * lightingColor.R / 255f,
                                                         shadowWeight * shadowColor.G / 255f + lightWeight * lightingColor.G / 255f,
                                                         shadowWeight * shadowColor.B / 255f + lightWeight * lightingColor.B / 255f,
                                                         shadowWeight * shadowColor.A / 255f + lightWeight * lightingColor.A / 255f);
                            spriteBatch.Draw(game.rect, destinationRectangle, lightLevel);
                        }
                        else
                        {
                            spriteBatch.Draw(game.rect, destinationRectangle, lightingColor);
                        }
                    }
                }
            }

            // Show all rays and theyre closest collisions:
            if (displayRays)
            {
                foreach (RaycastPoint rcp in region)
                {
                    Rectangle destinationRectangle = new Rectangle((int)rcp.Point.X - pixelSize / 2, (int)rcp.Point.Y - pixelSize / 2, pixelSize, pixelSize);
                    LineSegment lineSegment = new LineSegment(sourcePos, rcp.Point);
                    DrawLineSegment(lineSegment, spriteBatch);
                    //spriteBatch.Draw(game.rect, destinationRectangle, new Color(1f * region.IndexOf(rcp) / region.Count, 0, 1 - 1f * region.IndexOf(rcp) / region.Count));
                    spriteBatch.Draw(game.circle, destinationRectangle, Color.Yellow);
                }
            }

            // Show outline of visible region:
            if (displayOutline)
            {
                List<LineSegment> regionSegments = RegionLineSegments(visibleRegion);
                foreach (LineSegment lineSegment in regionSegments)
                {
                    DrawLineSegment(lineSegment, spriteBatch);
                }
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
        }

        private void DrawLineSegment(LineSegment lineSegment, SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle((int)lineSegment.A.X, (int)lineSegment.A.Y, (int)Vector2.Distance(lineSegment.A, lineSegment.B), 2);
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
            litBySwordBeam = false;
            litByPlayer = false;
            foreach (IUsableItem item in game.player.ActiveItems.FindAll((IUsableItem i) => i is SwordBeam))
            {
                if (Vector2.Distance(point, item.Position + game.currentRoom.Position) < swordBeamLightRadius)
                {
                    litBySwordBeam = true;
                    swordBeamPos = item.Position + game.currentRoom.Position;
                    break;
                }
            }
            if (!litBySwordBeam && region.Count < 3) return false;
            if (!litBySwordBeam && Vector2.Distance(game.player.Position + game.currentRoom.Position, point) > visionRadius) return false;
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
            litByPlayer = Math.Abs(total - (a1 + a2 + a3)) < .075f;
            return litByPlayer || litBySwordBeam;

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
            while (angle >= 2 * Math.PI)
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
