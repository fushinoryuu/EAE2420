using System;
using System.Collections.Generic;

namespace Assignment6
{
    class AStar
    {
        private GraphNode NodeA, NodeB, NodeC, NodeD, NodeE, NodeF, NodeG, NodeH, NodeI, NodeJ,
            NodeK, NodeL, NodeM, NodeN, NodeO, NodeP, Goal, Start;
        private List<GraphNode> OpenList = new List<GraphNode>();
        private List<GraphNode> CloseList = new List<GraphNode>();
        private List<string> SolutionList = new List<string>();

        public AStar(string input_start, string input_end)
        {
            Initialize(input_start, input_end);
        }

        private void Initialize(string input_start, string input_end)
        {
            List<GraphNode> node_list = new List<GraphNode>();
            BuildNodes(node_list);
            WireConnections();
            SetEndpoints(node_list, input_start, input_end);

            Start.CostSoFar = 0;
            Start.Heuristic = CalculateDistance(Start, Goal);
            Start.CameFrom = null;
            OpenList.Add(Start);

            RunAStar();
        }

        private void BuildNodes(List<GraphNode> node_list)
        {
            NodeA = new GraphNode() { Name = "A", X = -19, Y = 11, Connections = new Connection[2] };
            NodeB = new GraphNode() { Name = "B", X = -13, Y = 13, Connections = new Connection[2] };
            NodeC = new GraphNode() { Name = "C", X = 4, Y = 14, Connections = new Connection[3] };
            NodeD = new GraphNode() { Name = "D", X = -4, Y = 12, Connections = new Connection[3] };
            NodeE = new GraphNode() { Name = "E", X = -8, Y = 3, Connections = new Connection[7] };
            NodeF = new GraphNode() { Name = "F", X = -18, Y = 1, Connections = new Connection[2] };
            NodeG = new GraphNode() { Name = "G", X = -12, Y = -8, Connections = new Connection[3] };
            NodeH = new GraphNode() { Name = "H", X = 12, Y = -9, Connections = new Connection[3] };
            NodeI = new GraphNode() { Name = "I", X = -18, Y = -11, Connections = new Connection[2] };
            NodeJ = new GraphNode() { Name = "J", X = -4, Y = -11, Connections = new Connection[5] };
            NodeK = new GraphNode() { Name = "K", X = -12, Y = -14, Connections = new Connection[3] };
            NodeL = new GraphNode() { Name = "L", X = 2, Y = -18, Connections = new Connection[3] };
            NodeM = new GraphNode() { Name = "M", X = 18, Y = -13, Connections = new Connection[3] };
            NodeN = new GraphNode() { Name = "N", X = 4, Y = -9, Connections = new Connection[3] };
            NodeO = new GraphNode() { Name = "O", X = 22, Y = 11, Connections = new Connection[2] };
            NodeP = new GraphNode() { Name = "P", X = 18, Y = 3, Connections = new Connection[4] };

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
            NodeA.Connections[0] = new Connection() { Target = NodeB };
            NodeA.Connections[1] = new Connection() { Target = NodeE };

            NodeB.Connections[0] = new Connection() { Target = NodeA };
            NodeB.Connections[1] = new Connection() { Target = NodeD };

            NodeC.Connections[0] = new Connection() { Target = NodeD };
            NodeC.Connections[1] = new Connection() { Target = NodeE };
            NodeC.Connections[2] = new Connection() { Target = NodeP };

            NodeD.Connections[0] = new Connection() { Target = NodeB };
            NodeD.Connections[1] = new Connection() { Target = NodeC };
            NodeD.Connections[2] = new Connection() { Target = NodeE };

            NodeE.Connections[0] = new Connection() { Target = NodeA };
            NodeE.Connections[1] = new Connection() { Target = NodeC };
            NodeE.Connections[2] = new Connection() { Target = NodeD };
            NodeE.Connections[3] = new Connection() { Target = NodeG };
            NodeE.Connections[4] = new Connection() { Target = NodeH };
            NodeE.Connections[5] = new Connection() { Target = NodeJ };
            NodeE.Connections[6] = new Connection() { Target = NodeN };

            NodeF.Connections[0] = new Connection() { Target = NodeG };
            NodeF.Connections[1] = new Connection() { Target = NodeI };

            NodeG.Connections[0] = new Connection() { Target = NodeF };
            NodeG.Connections[1] = new Connection() { Target = NodeE };
            NodeG.Connections[2] = new Connection() { Target = NodeJ };

            NodeH.Connections[0] = new Connection() { Target = NodeN };
            NodeH.Connections[1] = new Connection() { Target = NodeE };
            NodeH.Connections[2] = new Connection() { Target = NodeP };

            NodeI.Connections[0] = new Connection() { Target = NodeF };
            NodeI.Connections[1] = new Connection() { Target = NodeK };

            NodeJ.Connections[0] = new Connection() { Target = NodeK };
            NodeJ.Connections[1] = new Connection() { Target = NodeG };
            NodeJ.Connections[2] = new Connection() { Target = NodeE };
            NodeJ.Connections[3] = new Connection() { Target = NodeN };
            NodeJ.Connections[4] = new Connection() { Target = NodeL };

            NodeK.Connections[0] = new Connection() { Target = NodeI };
            NodeK.Connections[1] = new Connection() { Target = NodeJ };
            NodeK.Connections[2] = new Connection() { Target = NodeL };

            NodeL.Connections[0] = new Connection() { Target = NodeK };
            NodeL.Connections[1] = new Connection() { Target = NodeJ };
            NodeL.Connections[2] = new Connection() { Target = NodeM };

            NodeM.Connections[0] = new Connection() { Target = NodeL };
            NodeM.Connections[1] = new Connection() { Target = NodeP };
            NodeM.Connections[2] = new Connection() { Target = NodeO };

            NodeN.Connections[0] = new Connection() { Target = NodeJ };
            NodeN.Connections[1] = new Connection() { Target = NodeE };
            NodeN.Connections[2] = new Connection() { Target = NodeH };

            NodeO.Connections[0] = new Connection() { Target = NodeP };
            NodeO.Connections[1] = new Connection() { Target = NodeM };

            NodeP.Connections[0] = new Connection() { Target = NodeH };
            NodeP.Connections[1] = new Connection() { Target = NodeC };
            NodeP.Connections[2] = new Connection() { Target = NodeO };
            NodeP.Connections[3] = new Connection() { Target = NodeM };
        }

        private void SetEndpoints(List<GraphNode> nodeList, string inputStart, string inputEnd)
        {
            foreach (GraphNode currentNode in nodeList)
            {
                if (currentNode.Name == inputStart)
                    Start = currentNode;
                if (currentNode.Name == inputEnd)
                    Goal = currentNode;
            }
        }

        private void RunAStar()
        {
            GraphNode current;

            while (OpenList.Count != 0)
            {
                current = FindBestNode();
                RemoveFromOpenList(current);
                ProcessConnections(current);
                AddToCloseList(current);
            }
        }

        private void ProcessNode(GraphNode current_node, GraphNode from_node)
        {
            current_node.CostSoFar += CalculateDistance(Start, current_node);
            current_node.Heuristic = CalculateDistance(current_node, Goal);

            current_node.CameFrom = from_node;
            OpenList.Add(current_node);
        }

        private GraphNode FindBestNode()
        {
            GraphNode best_node = OpenList[0];

            foreach (GraphNode list_node in OpenList)
                if (list_node.TotalEstimatedCost < best_node.TotalEstimatedCost)
                    best_node = list_node;
            
            return best_node;
        }

        private void RemoveFromOpenList(GraphNode node)
        {
            OpenList.Remove(node);
        }

        private void ProcessConnections(GraphNode current_node)
        {
            foreach (Connection connection in current_node.Connections)
            {
                if (InList(connection.Target, OpenList) || InList(connection.Target, CloseList))
                {
                    double temp_csf = connection.Target.CostSoFar + CalculateDistance(current_node, connection.Target);
                    if (temp_csf < connection.Target.CostSoFar)
                    {
                        ProcessNode(connection.Target, current_node);
                    }
                }
                else
                    ProcessNode(connection.Target, current_node);
            }
        }
        
        private void AddToCloseList(GraphNode node)
        {
            CloseList.Add(node);
        }

        private bool InList(GraphNode looking_for, List<GraphNode> list)
        {
            foreach (GraphNode node in list)
                if (node == looking_for)
                    return true;
            return false;
        }

        private double CalculateDistance(GraphNode start, GraphNode target)
        {
            return Math.Sqrt(Math.Pow(target.X - start.X, 2) + Math.Pow(target.Y - start.Y, 2));
        }

        public string ReconstructPath()
        {
            GraphNode runner = Goal;

            while (runner != null)
            {
                SolutionList.Add(runner.Name);
                runner = runner.CameFrom;
            }

            SolutionList.Reverse();
            return string.Join(", ", SolutionList);
        }
    }
}