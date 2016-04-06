using System;
using System.Collections.Generic;

namespace Assignment6
{
    class AStar
    {
        private GraphNode NodeA, NodeB, NodeC, NodeD, NodeE, NodeF, NodeG, NodeH, NodeI, NodeJ, NodeK, NodeL, NodeM, NodeN, NodeO, NodeP, Goal, Start;
        private List<GraphNode> OpenList, CloseList;
        private List<String> SolutionList;

        public AStar(string input_start, string input_end)
        {
            OpenList = new List<GraphNode>();
            CloseList = new List<GraphNode>();
            SolutionList = new List<String>();
            List<GraphNode> node_list = new List<GraphNode>();

            BuildNodes(node_list);
            WireConnections();
            SetGoals(node_list, input_start, input_end);

            Initialize();
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

        private void SetGoals(List<GraphNode> nodeList, string inputStart, string inputEnd)
        {
            foreach (GraphNode currentNode in nodeList)
            {
                if (currentNode.Name == inputStart)
                    Start = currentNode;
                if (currentNode.Name == inputEnd)
                    Goal = currentNode;
            }
        }

        private void Initialize()
        {
            Start.TotalEstimatedCost = 0;
            OpenList.Add(Start);
            FindLowestNode();
        }

        private void FindLowestNode()
        {
            GraphNode current_node = OpenList[0];
            
            foreach (GraphNode node in OpenList)
            {
                if (node.TotalEstimatedCost < current_node.TotalEstimatedCost)
                {
                    current_node = node;
                }
            }

            OpenList.Remove(current_node);

            foreach (Connection connection in current_node.Connections)
            {
                Console.WriteLine("Current Node: {0} Connection: {1}", current_node.Name, connection.Target.Name);
                if (connection.Target != Start)
                    connection.Target.Parent = current_node;
            }
            Console.WriteLine();
            ProcessOutBound(current_node);
        }

        private void ProcessOutBound(GraphNode current_node)
        {
            if (current_node == Goal)
            {
                Console.WriteLine("Found Goal\n");
                return;
            }

            else
            {
                for (int index = 0; index < current_node.Connections.Length; index++)
                {
                    current_node.Connections[index].Target.CostSoFar = current_node.CostSoFar + CalcDistance(current_node, current_node.Connections[index].Target);
                    current_node.Connections[index].Target.Heuristic = CalcDistance(current_node.Connections[index].Target, Goal);
                    current_node.Connections[index].Target.TotalEstimatedCost = current_node.Connections[index].Target.CostSoFar + current_node.Connections[index].Target.Heuristic;

                    if (InList(current_node.Connections[index].Target, OpenList))
                    {
                        //do nothing
                    }

                    if (InList(current_node.Connections[index].Target, CloseList))
                    {
                        //do nothing
                    }

                    else
                    {
                        OpenList.Add(current_node.Connections[index].Target);
                    }
                }
                CloseList.Add(current_node);
                FindLowestNode();
            }
        }

        private bool InList(GraphNode looking_for, List<GraphNode> list)
        {
            foreach (GraphNode node in list)
                if (node == looking_for)
                    LowerEstimate(looking_for, node);
            return false;
        }

        private bool LowerEstimate(GraphNode first, GraphNode second)
        {
            if (first.TotalEstimatedCost < second.TotalEstimatedCost)
                return true;
            return false;
        }
        
        private double CalcDistance(GraphNode start, GraphNode target)
        {
            return Math.Sqrt(Math.Pow(target.X - start.X, 2) + Math.Pow(target.Y - start.Y, 2));
        }

        public string ReconstructPath()
        {
            GraphNode runner = Goal;

            while (runner != null)
            {
                SolutionList.Add(runner.Name);
                runner = runner.Parent;
            }

            SolutionList.Reverse();
            return string.Join(", ", SolutionList);
        }
    }
}