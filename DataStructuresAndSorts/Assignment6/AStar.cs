//using System;
//using System.Collections.Generic;

//namespace Assignment6
//{
//    class AStar
//    {
//        private GraphNode NodeA, NodeB, NodeC, NodeD, NodeE, NodeF, NodeG, NodeH, NodeI, NodeJ, NodeK, NodeL, NodeM, NodeN, NodeO, NodeP, Goal, Start;
//        private List<GraphNode> OpenList, CloseList;

//        public AStar(string input_start, string input_end)
//        {
//            OpenList = new List<GraphNode>();
//            CloseList = new List<GraphNode>();
//            List<GraphNode> node_list = new List<GraphNode>();

//            BuildNodes(node_list);
//            WireConnections();
//            SetGoals(node_list, input_start, input_end);
//            ProcessNode(Start);
//        }

//        private void BuildNodes(List<GraphNode> node_list)
//        {
//            NodeA = new GraphNode() { Name = "A", X = -19, Y = 11, Connections = new Connection[2] };
//            NodeB = new GraphNode() { Name = "B", X = -13, Y = 13, Connections = new Connection[2] };
//            NodeC = new GraphNode() { Name = "C", X = 4, Y = 14, Connections = new Connection[3] };
//            NodeD = new GraphNode() { Name = "D", X = -4, Y = 12, Connections = new Connection[3] };
//            NodeE = new GraphNode() { Name = "E", X = -8, Y = 3, Connections = new Connection[7] };
//            NodeF = new GraphNode() { Name = "F", X = -18, Y = 1, Connections = new Connection[2] };
//            NodeG = new GraphNode() { Name = "G", X = -12, Y = -8, Connections = new Connection[3] };
//            NodeH = new GraphNode() { Name = "H", X = 12, Y = -9, Connections = new Connection[3] };
//            NodeI = new GraphNode() { Name = "I", X = -18, Y = -11, Connections = new Connection[2] };
//            NodeJ = new GraphNode() { Name = "J", X = -4, Y = -11, Connections = new Connection[5] };
//            NodeK = new GraphNode() { Name = "K", X = -12, Y = -14, Connections = new Connection[3] };
//            NodeL = new GraphNode() { Name = "L", X = 2, Y = -18, Connections = new Connection[3] };
//            NodeM = new GraphNode() { Name = "M", X = 18, Y = -13, Connections = new Connection[3] };
//            NodeN = new GraphNode() { Name = "N", X = 4, Y = -9, Connections = new Connection[3] };
//            NodeO = new GraphNode() { Name = "O", X = 22, Y = 11, Connections = new Connection[2] };
//            NodeP = new GraphNode() { Name = "P", X = 18, Y = 3, Connections = new Connection[4] };

//            node_list.Add(NodeA);
//            node_list.Add(NodeB);
//            node_list.Add(NodeC);
//            node_list.Add(NodeD);
//            node_list.Add(NodeE);
//            node_list.Add(NodeF);
//            node_list.Add(NodeG);
//            node_list.Add(NodeH);
//            node_list.Add(NodeI);
//            node_list.Add(NodeJ);
//            node_list.Add(NodeK);
//            node_list.Add(NodeL);
//            node_list.Add(NodeM);
//            node_list.Add(NodeN);
//            node_list.Add(NodeO);
//            node_list.Add(NodeP);
//        }

//        private void WireConnections()
//        {
//            NodeA.Connections[0] = new Connection() { Target = NodeB };
//            NodeA.Connections[1] = new Connection() { Target = NodeE };

//            NodeB.Connections[0] = new Connection() { Target = NodeA };
//            NodeB.Connections[1] = new Connection() { Target = NodeD };

//            NodeC.Connections[0] = new Connection() { Target = NodeD };
//            NodeC.Connections[1] = new Connection() { Target = NodeE };
//            NodeC.Connections[2] = new Connection() { Target = NodeP };

//            NodeD.Connections[0] = new Connection() { Target = NodeB };
//            NodeD.Connections[1] = new Connection() { Target = NodeC };
//            NodeD.Connections[2] = new Connection() { Target = NodeE };

//            NodeE.Connections[0] = new Connection() { Target = NodeA };
//            NodeE.Connections[1] = new Connection() { Target = NodeC };
//            NodeE.Connections[2] = new Connection() { Target = NodeD };
//            NodeE.Connections[3] = new Connection() { Target = NodeG };
//            NodeE.Connections[4] = new Connection() { Target = NodeH };
//            NodeE.Connections[5] = new Connection() { Target = NodeJ };
//            NodeE.Connections[6] = new Connection() { Target = NodeN };

//            NodeF.Connections[0] = new Connection() { Target = NodeG };
//            NodeF.Connections[1] = new Connection() { Target = NodeI };

//            NodeG.Connections[0] = new Connection() { Target = NodeF };
//            NodeG.Connections[1] = new Connection() { Target = NodeE };
//            NodeG.Connections[2] = new Connection() { Target = NodeJ };

//            NodeH.Connections[0] = new Connection() { Target = NodeN };
//            NodeH.Connections[1] = new Connection() { Target = NodeE };
//            NodeH.Connections[2] = new Connection() { Target = NodeP };

//            NodeI.Connections[0] = new Connection() { Target = NodeF };
//            NodeI.Connections[1] = new Connection() { Target = NodeK };

//            NodeJ.Connections[0] = new Connection() { Target = NodeK };
//            NodeJ.Connections[1] = new Connection() { Target = NodeG };
//            NodeJ.Connections[2] = new Connection() { Target = NodeE };
//            NodeJ.Connections[3] = new Connection() { Target = NodeN };
//            NodeJ.Connections[4] = new Connection() { Target = NodeL };

//            NodeK.Connections[0] = new Connection() { Target = NodeI };
//            NodeK.Connections[1] = new Connection() { Target = NodeJ };
//            NodeK.Connections[2] = new Connection() { Target = NodeL };

//            NodeL.Connections[0] = new Connection() { Target = NodeK };
//            NodeL.Connections[1] = new Connection() { Target = NodeJ };
//            NodeL.Connections[2] = new Connection() { Target = NodeM };

//            NodeM.Connections[0] = new Connection() { Target = NodeL };
//            NodeM.Connections[1] = new Connection() { Target = NodeP };
//            NodeM.Connections[2] = new Connection() { Target = NodeO };

//            NodeN.Connections[0] = new Connection() { Target = NodeJ };
//            NodeN.Connections[1] = new Connection() { Target = NodeE };
//            NodeN.Connections[2] = new Connection() { Target = NodeH };

//            NodeO.Connections[0] = new Connection() { Target = NodeP };
//            NodeO.Connections[1] = new Connection() { Target = NodeM };

//            NodeP.Connections[0] = new Connection() { Target = NodeH };
//            NodeP.Connections[1] = new Connection() { Target = NodeC };
//            NodeP.Connections[2] = new Connection() { Target = NodeO };
//            NodeP.Connections[3] = new Connection() { Target = NodeM };
//        }

//        private void SetGoals(List<GraphNode> nodeList, string inputStart, string inputEnd)
//        {
//            foreach (GraphNode currentNode in nodeList)
//                if (currentNode.Name == inputStart)
//                    Start = currentNode;
//                else if (currentNode.Name == inputEnd)
//                    Goal = currentNode;
//        }

//        private void ProcessNode(GraphNode current_node)
//        {
//            for (int index = 0; index < current_node.Connections.Length; index++)
//            {
//                current_node.Connections[index].CostSoFar = CalcDistance(Start, current_node);
//                current_node.Heuristic = CalcDistance(current_node, Goal);
//                current_node.Connections[index].TotalEstimatedCost =
//                    current_node.Connections[index].CostSoFar + current_node.Heuristic;
//                if (current_node.Name == Start.Name)
//                    current_node.Connections[index].From = null;
//                else
//                    current_node.Connections[index].From = current_node; // FIX
//            }
//            OpenList.Add(current_node);
//        }

//        private void ProcessOutBound()
//        {

//        }

//        private void PickNextNode()
//        {

//        }

//        private double CalcDistance(GraphNode start, GraphNode target)
//        {
//            return Math.Sqrt(Math.Pow(target.X - start.X, 2) + Math.Pow(target.Y - start.Y, 2));
//        }

//        private void ReconstructPath(GraphNode came_from, GraphNode current)
//        {

//        }
//    }
//}