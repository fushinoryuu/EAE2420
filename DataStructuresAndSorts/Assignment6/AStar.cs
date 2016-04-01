using System;
using System.Collections.Generic;

namespace Assignment6
{
    class AStar
    {
        private GraphNode A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, goal, start;
        private List<GraphNode> openList, closeList;

        public AStar(string inputStart, string inputEnd)
        {
            openList = new List<GraphNode>();
            closeList = new List<GraphNode>();
            List<GraphNode> nodeList = new List<GraphNode>();

            BuildNodes(nodeList);
            WireConnections();
            SetGoals(nodeList, inputStart, inputEnd);
        }

        private void BuildNodes(List<GraphNode> nodeList)
        {
            A = new GraphNode() { Name = "A", X = -19, Y = 11, Connections = new Connection[2] };
            B = new GraphNode() { Name = "B", X = -13, Y = 13, Connections = new Connection[2] };
            C = new GraphNode() { Name = "C", X = 4, Y = 14, Connections = new Connection[3] };
            D = new GraphNode() { Name = "D", X = -4, Y = 12, Connections = new Connection[3] };
            E = new GraphNode() { Name = "E", X = -8, Y = 3, Connections = new Connection[7] };
            F = new GraphNode() { Name = "F", X = -18, Y = 1, Connections = new Connection[2] };
            G = new GraphNode() { Name = "G", X = -12, Y = -8, Connections = new Connection[3] };
            H = new GraphNode() { Name = "H", X = 12, Y = -9, Connections = new Connection[3] };
            I = new GraphNode() { Name = "I", X = -18, Y = -11, Connections = new Connection[2] };
            J = new GraphNode() { Name = "J", X = -4, Y = -11, Connections = new Connection[5] };
            K = new GraphNode() { Name = "K", X = -12, Y = -14, Connections = new Connection[3] };
            L = new GraphNode() { Name = "L", X = 2, Y = -18, Connections = new Connection[3] };
            M = new GraphNode() { Name = "M", X = 18, Y = -13, Connections = new Connection[3] };
            N = new GraphNode() { Name = "N", X = 4, Y = -9, Connections = new Connection[3] };
            O = new GraphNode() { Name = "O", X = 22, Y = 11, Connections = new Connection[2] };
            P = new GraphNode() { Name = "P", X = 18, Y = 3, Connections = new Connection[4] };

            nodeList.Add(A);
            nodeList.Add(B);
            nodeList.Add(C);
            nodeList.Add(D);
            nodeList.Add(E);
            nodeList.Add(F);
            nodeList.Add(G);
            nodeList.Add(H);
            nodeList.Add(I);
            nodeList.Add(J);
            nodeList.Add(K);
            nodeList.Add(L);
            nodeList.Add(M);
            nodeList.Add(N);
            nodeList.Add(O);
            nodeList.Add(P);
        }

        private void WireConnections()
        {
            A.Connections[0] = new Connection() { Target = B };
            A.Connections[1] = new Connection() { Target = E };

            B.Connections[0] = new Connection() { Target = A };
            B.Connections[1] = new Connection() { Target = D };

            C.Connections[0] = new Connection() { Target = D };
            C.Connections[1] = new Connection() { Target = E };
            C.Connections[2] = new Connection() { Target = P };

            D.Connections[0] = new Connection() { Target = B };
            D.Connections[1] = new Connection() { Target = C };
            D.Connections[2] = new Connection() { Target = E };

            E.Connections[0] = new Connection() { Target = A };
            E.Connections[1] = new Connection() { Target = C };
            E.Connections[2] = new Connection() { Target = D };
            E.Connections[3] = new Connection() { Target = G };
            E.Connections[4] = new Connection() { Target = H };
            E.Connections[5] = new Connection() { Target = J };
            E.Connections[6] = new Connection() { Target = N };

            F.Connections[0] = new Connection() { Target = G };
            F.Connections[1] = new Connection() { Target = I };

            G.Connections[0] = new Connection() { Target = F };
            G.Connections[1] = new Connection() { Target = E };
            G.Connections[2] = new Connection() { Target = J };

            H.Connections[0] = new Connection() { Target = N };
            H.Connections[1] = new Connection() { Target = E };
            H.Connections[2] = new Connection() { Target = P };

            I.Connections[0] = new Connection() { Target = F };
            I.Connections[1] = new Connection() { Target = K };

            J.Connections[0] = new Connection() { Target = K };
            J.Connections[1] = new Connection() { Target = G };
            J.Connections[2] = new Connection() { Target = E };
            J.Connections[3] = new Connection() { Target = N };
            J.Connections[4] = new Connection() { Target = L };

            K.Connections[0] = new Connection() { Target = I };
            K.Connections[1] = new Connection() { Target = J };
            K.Connections[2] = new Connection() { Target = L };

            L.Connections[0] = new Connection() { Target = K };
            L.Connections[1] = new Connection() { Target = J };
            L.Connections[2] = new Connection() { Target = M };

            M.Connections[0] = new Connection() { Target = L };
            M.Connections[1] = new Connection() { Target = P };
            M.Connections[2] = new Connection() { Target = O };

            N.Connections[0] = new Connection() { Target = J };
            N.Connections[1] = new Connection() { Target = E };
            N.Connections[2] = new Connection() { Target = H };

            O.Connections[0] = new Connection() { Target = P };
            O.Connections[1] = new Connection() { Target = M };

            P.Connections[0] = new Connection() { Target = H };
            P.Connections[1] = new Connection() { Target = C };
            P.Connections[2] = new Connection() { Target = O };
            P.Connections[3] = new Connection() { Target = M };
        }

        private void SetGoals(List<GraphNode> nodeList, string inputStart, string inputEnd)
        {
            foreach (GraphNode currentNode in nodeList)
            {
                if (currentNode.Name == inputStart)
                {
                    start = currentNode;
                    openList.Add(start);
                }
                else if (currentNode.Name == inputEnd)
                {
                    goal = currentNode;
                }
            }
        }

        private void PickNextNode()
        {

        }

        private void ProcessNode(GraphNode currentNode)
        {

        }

        private void CalcCostSoFar()
        {

        }

        private void CalcHeuristic()
        {

        }

        private void CalcTotalCost()
        {

        }

        private double CalcDistance(GraphNode start, GraphNode target)
        {
            return Math.Sqrt(Math.Pow(target.X - start.X, 2) + Math.Pow(target.Y - start.Y, 2));
        }
    }
}