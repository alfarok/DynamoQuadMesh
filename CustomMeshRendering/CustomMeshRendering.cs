using Autodesk.DesignScript.Interfaces;
using Autodesk.DesignScript.Runtime;
using Autodesk.DesignScript.Geometry;
using System.Collections.Generic;

namespace Examples
{
    // This sample class creates a ZeroTouch nodes that
    // takes 4 vertices and renders a custom mesh that is
    // composed of 2 triangles representing a quad.

    public class CustomMeshRendering : IGraphicItem
    {
        private CustomMeshRendering() { }
        private readonly List<Vector> vertices;

        /// <summary>
        /// Create an object which renders custom geometry.
        /// </summary>
        [IsVisibleInDynamoLibrary(false)]
        public CustomMeshRendering(List<Vector> triangleVertices)
        {
            this.vertices = triangleVertices;
        }

        /// <summary>
        /// A Zero Touch Node for Displaying Quads as 2 Triangles
        /// </summary>
        /// <param name="a">Vertex A</param>
        /// <param name="b">Vertex B</param>
        /// <param name="c">Vertex C</param>
        /// <param name="d">Vertex D</param>
        /// <returns></returns>
        public static CustomMeshRendering CreateQuadMesh(List<Vector> a, List<Vector> b, List<Vector> c, List<Vector> d)
        {
            // Verify equal inputs
            if (a.Count != b.Count && b.Count != c.Count && c.Count != d.Count)
            {
                return null;
            }

            List<Vector> triangleVertices = new List<Vector>();

            // 6 verts for 1 Quad = 2 Tris
            for (int i = 0; i < a.Count; i++)
            {
                // Triangle 1
                triangleVertices.Add(a[i]);
                triangleVertices.Add(b[i]);
                triangleVertices.Add(c[i]);

                // Triangle 2
                triangleVertices.Add(c[i]);
                triangleVertices.Add(d[i]);
                triangleVertices.Add(a[i]);
            }

            return new CustomMeshRendering(triangleVertices);
        }

        [IsVisibleInDynamoLibrary(false)]
        public void Tessellate(IRenderPackage package, TessellationParameters parameters)
        {
            // Dynamo's renderer uses IRenderPackage objects
            // to store data for rendering. The Tessellate method
            // give you an IRenderPackage object which you can fill
            // with render data.

            // Set RequiresPerVertexColoration to let the renderer
            // know that you needs to use a per-vertex color shader.
            package.RequiresPerVertexColoration = true;

            AddColoredQuadToPackage(package);
        }

        private void AddColoredQuadToPackage(IRenderPackage package)
        {
            // For each quad
            for (int i = 0; i < vertices.Count; i += 6)
            {
                // Meshes
                
                // Triangle 1
                package.AddTriangleVertex(vertices[i].X, vertices[i].Y, vertices[i].Z);
                package.AddTriangleVertex(vertices[i + 1].X, vertices[i + 1].Y, vertices[i + 1].Z);
                package.AddTriangleVertex(vertices[i + 2].X, vertices[i + 2].Y, vertices[i + 2].Z);

                package.AddTriangleVertexColor(32, 178, 170, 255);
                package.AddTriangleVertexColor(32, 178, 170, 255);
                package.AddTriangleVertexColor(32, 178, 170, 255);

                package.AddTriangleVertexNormal(0, 0, 1);
                package.AddTriangleVertexNormal(0, 0, 1);
                package.AddTriangleVertexNormal(0, 0, 1);

                package.AddTriangleVertexUV(0, 0);
                package.AddTriangleVertexUV(0, 0);
                package.AddTriangleVertexUV(0, 0);

                // Triangle 2
                package.AddTriangleVertex(vertices[i + 3].X, vertices[i + 3].Y, vertices[i + 3].Z);
                package.AddTriangleVertex(vertices[i + 4].X, vertices[i + 4].Y, vertices[i + 4].Z);
                package.AddTriangleVertex(vertices[i + 5].X, vertices[i + 5].Y, vertices[i + 5].Z);

                package.AddTriangleVertexColor(32, 178, 170, 255);
                package.AddTriangleVertexColor(32, 178, 170, 255);
                package.AddTriangleVertexColor(32, 178, 170, 255);

                package.AddTriangleVertexNormal(0, 0, 1);
                package.AddTriangleVertexNormal(0, 0, 1);
                package.AddTriangleVertexNormal(0, 0, 1);

                package.AddTriangleVertexUV(0, 0);
                package.AddTriangleVertexUV(0, 0);
                package.AddTriangleVertexUV(0, 0);

                // Edges
                // NOTE: this could be reduced to less than 6 vertices
                // but for the purposes of this example it is more clear

                // Triangle 1
                package.AddLineStripVertex(vertices[i].X, vertices[i].Y, vertices[i].Z);
                package.AddLineStripVertex(vertices[i + 1].X, vertices[i + 1].Y, vertices[i + 1].Z);
                package.AddLineStripVertex(vertices[i + 2].X, vertices[i + 2].Y, vertices[i + 2].Z);
                // Triangle 2
                package.AddLineStripVertex(vertices[i + 3].X, vertices[i + 3].Y, vertices[i + 3].Z);
                package.AddLineStripVertex(vertices[i + 4].X, vertices[i + 4].Y, vertices[i + 4].Z);
                package.AddLineStripVertex(vertices[i + 5].X, vertices[i + 5].Y, vertices[i + 5].Z);

                package.AddLineStripVertexColor(0, 0, 0, 255);
                package.AddLineStripVertexColor(0, 0, 0, 255);
                package.AddLineStripVertexColor(0, 0, 0, 255);
                package.AddLineStripVertexColor(0, 0, 0, 255);
                package.AddLineStripVertexColor(0, 0, 0, 255);
                package.AddLineStripVertexColor(0, 0, 0, 255);

                package.AddLineStripVertexCount(6);
            }
        }
    }
}