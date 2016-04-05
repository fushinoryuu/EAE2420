using System;
using System.Collections.Generic;

namespace Assignment6
{
    class NewAStar
    {
        private NewGraphNode NodeA, NodeB, NodeC, NodeD, NodeE, NodeF, NodeG, NodeH, NodeI, NodeJ, NodeK, NodeL, NodeM, NodeN, NodeO, NodeP, Goal, Start;
        private List<NewGraphNode> OpenList, CloseList;

        public NewAStar(string input_start, string input_end)
        {
            OpenList = new List<NewGraphNode>();
            CloseList = new List<NewGraphNode>();
            List<NewGraphNode> node_list = new List<NewGraphNode>();

            BuildNodes(node_list);
            WireConnections();
            SetGoals(node_list, input_start, input_end);

            Initialize();
        }

        private void BuildNodes(List<NewGraphNode> node_list)
        {
            NodeA = new NewGraphNode() { Name = "A", X = -19, Y = 11, Connections = new NewConnection[2] };
            NodeB = new NewGraphNode() { Name = "B", X = -13, Y = 13, Connections = new NewConnection[2] };
            NodeC = new NewGraphNode() { Name = "C", X = 4, Y = 14, Connections = new NewConnection[3] };
            NodeD = new NewGraphNode() { Name = "D", X = -4, Y = 12, Connections = new NewConnection[3] };
            NodeE = new NewGraphNode() { Name = "E", X = -8, Y = 3, Connections = new NewConnection[7] };
            NodeF = new NewGraphNode() { Name = "F", X = -18, Y = 1, Connections = new NewConnection[2] };
            NodeG = new NewGraphNode() { Name = "G", X = -12, Y = -8, Connections = new NewConnection[3] };
            NodeH = new NewGraphNode() { Name = "H", X = 12, Y = -9, Connections = new NewConnection[3] };
            NodeI = new NewGraphNode() { Name = "I", X = -18, Y = -11, Connections = new NewConnection[2] };
            NodeJ = new NewGraphNode() { Name = "J", X = -4, Y = -11, Connections = new NewConnection[5] };
            NodeK = new NewGraphNode() { Name = "K", X = -12, Y = -14, Connections = new NewConnection[3] };
            NodeL = new NewGraphNode() { Name = "L", X = 2, Y = -18, Connections = new NewConnection[3] };
            NodeM = new NewGraphNode() { Name = "M", X = 18, Y = -13, Connections = new NewConnection[3] };
            NodeN = new NewGraphNode() { Name = "N", X = 4, Y = -9, Connections = new NewConnection[3] };
            NodeO = new NewGraphNode() { Name = "O", X = 22, Y = 11, Connections = new NewConnection[2] };
            NodeP = new NewGraphNode() { Name = "P", X = 18, Y = 3, Connections = new NewConnection[4] };

            node_list.Add(NodeA);
            node_list.Add(NodeB);
            node_list.Add(NodeC);
            node_list.Add(NodeD);
            node_list.Add(NodeE);
            node_list.Add(NodeF);
            node_list.Add(NodeG);
            node_list.Add(NodeH);
            node_list.Add(NodeI);
            node_list.Add(NodeJ);
            node_list.Add(NodeK);
            node_list.Add(NodeL);
            node_list.Add(NodeM);
            node_list.Add(NodeN);
            node_list.Add(NodeO);
            node_list.Add(NodeP);
        }

        private void WireConnections()
        {
            NodeA.Connections[0] = new NewConnection() { Target = NodeB };
            NodeA.Connections[1] = new NewConnection() { Target = NodeE };

            NodeB.Connections[0] = new NewConnection() { Target = NodeA };
            NodeB.Connections[1] = new NewConnection() { Target = NodeD };

            NodeC.Connections[0] = new NewConnection() { Target = NodeD };
            NodeC.Connections[1] = new NewConnection() { Target = NodeE };
            NodeC.Connections[2] = new NewConnection() { Target = NodeP };

            NodeD.Connections[0] = new NewConnection() { Target = NodeB };
            NodeD.Connections[1] = new NewConnection() { Target = NodeC };
            NodeD.Connections[2] = new NewConnection() { Target = NodeE };

            NodeE.Connections[0] = new NewConnection() { Target = NodeA };
            NodeE.Connections[1] = new NewConnection() { Target = NodeC };
            NodeE.Connections[2] = new NewConnection() { Target = NodeD };
            NodeE.Connections[3] = new NewConnection() { Target = NodeG };
            NodeE.Connections[4] = new NewConnection() { Target = NodeH };
            NodeE.Connections[5] = new NewConnection() { Target = NodeJ };
            NodeE.Connections[6] = new NewConnection() { Target = NodeN };

            NodeF.Connections[0] = new NewConnection() { Target = NodeG };
            NodeF.Connections[1] = new NewConnection() { Target = NodeI };

            NodeG.Connections[0] = new NewConnection() { Target = NodeF };
            NodeG.Connections[1] = new NewConnection() { Target = NodeE };
            NodeG.Connections[2] = new NewConnection() { Target = NodeJ };

            NodeH.Connections[0] = new NewConnection() { Target = NodeN };
            NodeH.Connections[1] = new NewConnection() { Target = NodeE };
            NodeH.Connections[2] = new NewConnection() { Target = NodeP };

            NodeI.Connections[0] = new NewConnection() { Target = NodeF };
            NodeI.Connections[1] = new NewConnection() { Target = NodeK };

            NodeJ.Connections[0] = new NewConnection() { Target = NodeK };
            NodeJ.Connections[1] = new NewConnection() { Target = NodeG };
            NodeJ.Connections[2] = new NewConnection() { Target = NodeE };
            NodeJ.Connections[3] = new NewConnection() { Target = NodeN };
            NodeJ.Connections[4] = new NewConnection() { Target = NodeL };

            NodeK.Connections[0] = new NewConnection() { Target = NodeI };
            NodeK.Connections[1] = new NewConnection() { Target = NodeJ };
            NodeK.Connections[2] = new NewConnection() { Target = NodeL };

            NodeL.Connections[0] = new NewConnection() { Target = NodeK };
            NodeL.Connections[1] = new NewConnection() { Target = NodeJ };
            NodeL.Connections[2] = new NewConnection() { Target = NodeM };

            NodeM.Connections[0] = new NewConnection() { Target = NodeL };
            NodeM.Connections[1] = new NewConnection() { Target = NodeP };
            NodeM.Connections[2] = new NewConnection() { Target = NodeO };

            NodeN.Connections[0] = new NewConnection() { Target = NodeJ };
            NodeN.Connections[1] = new NewConnection() { Target = NodeE };
            NodeN.Connections[2] = new NewConnection() { Target = NodeH };

            NodeO.Connections[0] = new NewConnection() { Target = NodeP };
            NodeO.Connections[1] = new NewConnection() { Target = NodeM };

            NodeP.Connections[0] = new NewConnection() { Target = NodeH };
            NodeP.Connections[1] = new NewConnection() { Target = NodeC };
            NodeP.Connections[2] = new NewConnection() { Target = NodeO };
            NodeP.Connections[3] = new NewConnection() { Target = NodeM };            
        }

        private void SetGoals(List<NewGraphNode> nodeList, string inputStart, string inputEnd)
        {
            foreach (NewGraphNode currentNode in nodeList)
                if (currentNode.Name == inputStart)
                    Start = currentNode;
                else if (currentNode.Name == inputEnd)
                    Goal = currentNode;
        }

        private void Initialize()
        {
            Start.F = 0;
            OpenList.Add(Start);
            FindLowestNode();
        }

        private void FindLowestNode()
        {
            NewGraphNode q = OpenList[0];
            
            foreach (NewGraphNode node in OpenList)
            {
                if (node.F < q.F)
                {
                    q = node;
                }
            }

            OpenList.Remove(q);

            for (int i = 0; i < q.Connections.Length; i++)
            {
                q.Connections[i].From = q;
            }

            ProcessOutBound(q);
        }

        private void ProcessOutBound(NewGraphNode q)
        {
            if (q == Goal)
            {
                Console.WriteLine("Found Node");
                return;
            }


        }

        private double CalcDistance(NewGraphNode start, NewGraphNode target)
        {
            return Math.Sqrt(Math.Pow(target.X - start.X, 2) + Math.Pow(target.Y - start.Y, 2));
        }

        private void ReconstructPath(NewGraphNode came_from, NewGraphNode current)
        {

        }
    }
}