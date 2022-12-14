using System;
class App {
    private BinarySearchTree<Int32>? tree;
    public void ChooseAction() {

        bool doContinue = true;
        while(doContinue) {
            Console.Clear();
            Console.Write(
@"Choose one of the following options:
1. Add node;
2. Remove node;
3. Tree traversal:
    3.1. InOrder;
    3.2. PreOrder;
    3.3. PostOrder;
4. Show tree;
5. Search;
6. Balance tree;
7. Threaded BST:
    7.1. Print threaded BST;
    7.2. InOrder traversal of threaded BST;
0. Exit.
> "
            );
            String? choice = Console.ReadLine();
            if (choice == null) continue;
            switch(choice) {
                case "1": {
                    AddNode();
                    break;
                }
                case "2": {
                    RemoveNode();
                    break;
                }
                case "3": {
                    Traverse();
                    break;
                }
                case "3.1": {
                    TraverseInOrder();
                    break;
                }
                case "3.2": {
                    TraversePreOrder();
                    break;
                }
                case "3.3": {
                    TraversePostOrder();
                    break;
                }
                case "4": {
                    PrintTree();
                    break;
                }
                case "5": {
                    Search();
                    break;
                }
                case "6": {
                    BalanceBST();
                    break;
                }
                case "7": {
                    ThreadedBST();
                    break;
                }
                case "7.1": {
                    PrintThreadedBST();
                    break;
                }
                case "7.2": {
                    InOrderThreaded();
                    break;
                }
                case "0": {
                    doContinue = false;
                    break;
                }
                default: {
                    break;
                }
            }
        }
    }

    // Add node to the tree
    void AddNode() {
        String text = 
@"Enter value of new node:
> ";
        Int32 value = ReadInt32(text);
        if (tree == null) {
            tree = new BinarySearchTree<Int32>(value);
        } else {
            tree.Insert(value);
        }
    }

    // Remove node from the tree
    void RemoveNode() {
        if (tree == null) {
            Console.WriteLine("There are no nodes in tree. Add nodes first.");
            WaitKey();
        } else {
            String text = 
@"Enter value of node to remove
> ";        
            Int32 value = ReadInt32(text);
            if (!tree.Contains(value)) {
                Console.WriteLine("There are no nodes with such value.");
                WaitKey();
            } else {
                List<Node<Int32>> nodes = tree.ExportBST();
                for (int i = 0; i < nodes.Count; i++) {
                    if (nodes[i].value == value)
                        nodes.RemoveAt(i);
                }
                BinarySearchTree<Int32> treeCopy = new BinarySearchTree<Int32>(nodes[0].value);
                for (int i = 1; i < nodes.Count; i++) {
                    treeCopy.Insert(nodes[i].value);
                }
                treeCopy.BuildTree();
                tree = treeCopy;
            }
        }
    }

    // Display text, read string and parse to Int32. 
    Int32 ReadInt32(String text) {
        Int32 value = 0;
        bool doContinue = true;
        while (doContinue) {
            Console.Clear();
            Console.Write(text);

            int parsedResult;
            if(int.TryParse(Console.ReadLine(), out parsedResult)) {
                value = parsedResult;
                doContinue = false;
            }
        }

        return value;
    }

    // Pick what type of traversion to show.
    void Traverse() {
        if (tree == null) {
            Console.Clear();
            Console.WriteLine("There are no nodes in tree. Add nodes to traverse.");
            WaitKey();
            return;
        }
        bool doContinue = true;
        while(doContinue) {
            Console.Clear();
            Console.Write(
@"Choose one of the following options:
1. InOrder traversal;
2. PreOrder traversal;
3. PostOrder traversal.
> ");
            String? choice = Console.ReadLine();
            if (choice == null) continue;
            switch(choice) {
                case "1": {
                    TraverseInOrder();
                    doContinue = false;
                    break;
                }
                case "2": {
                    TraversePreOrder();
                    doContinue = false;
                    break;
                }
                case "3": {
                    TraversePostOrder();
                    doContinue = false;
                    break;
                }
                default: {
                    break;
                }
            }
        }
    }

    void TraverseInOrder() {
        Console.Clear();
        if (tree == null) {AddNode();
            Console.WriteLine("There are no nodes in tree. Add nodes to traverse.");
            WaitKey();
            return;
        }
        
        List<Int32> treeTraversed = tree.TraversalLong(tree.GetRoot());
        PrintTreeListInt(treeTraversed);
        treeTraversed = tree.InOrder(tree.GetRoot());
        PrintTreeListInt(treeTraversed);
        WaitKey();
    }

    void TraversePreOrder() {
        Console.Clear();
        if (tree == null) {
            Console.WriteLine("There are no nodes in tree. Add nodes to traverse.");
            WaitKey();
            return;
        }

        List<Int32> treeTraversed = tree.TraversalLong(tree.GetRoot());
        PrintTreeListInt(treeTraversed);
        treeTraversed = tree.PreOrder(tree.GetRoot());
        PrintTreeListInt(treeTraversed);
        WaitKey();
    }

    void TraversePostOrder() {
        Console.Clear();
        if (tree == null) {
            Console.WriteLine("There are no nodes in tree. Add nodes to traverse.");
            WaitKey();
            return;
        }
        
        List<Int32> treeTraversed = tree.TraversalLong(tree.GetRoot());
        PrintTreeListInt(treeTraversed);
        treeTraversed = tree.PostOrder(tree.GetRoot());
        PrintTreeListInt(treeTraversed);
        Console.WriteLine(treeTraversed);
        WaitKey();
    }

    void Search() {
        Console.Clear();
        if (tree == null) {
            Console.WriteLine("Can't search empty tree. Add nodes");
        } else {
            int value = ReadInt32(
@"Enter value to search:
> "
            );
            if (tree.Contains(value))
                Console.WriteLine($"Value {value} was found in tree.");
            else 
                Console.WriteLine($"Value {value} was NOT found in tree.");
            
        }
        WaitKey();
    }

    void BalanceBST() {
        Console.Clear();
        if (tree == null) {
            Console.WriteLine("Can't balance empty tree. Add nodes.");
        } else {
            tree.BuildTree();
            Console.WriteLine("Sucessfully balanced BST.");
        }
        WaitKey();
    }

    void ThreadedBST() {
        bool doContinue = true;
        while (doContinue) {
            Console.Clear();
            Console.Write(
@"Choose one of the following options:
1. Print threaded BST;
2. InOrder traversal of threaded BST.
> ");
            String? choice = Console.ReadLine();
            if (choice == null) continue;
            switch(choice) {
                case "1.": {
                    PrintThreadedBST();
                    doContinue = false;
                    break;
                }
                case "2.": {
                    InOrderThreaded();
                    doContinue = false;
                    break;
                }
                default: {
                    break;
                }
            }
        }
        
    }

    void PrintThreadedBST() {
        Console.Clear();
        if (tree == null) {
            Console.WriteLine("Can't convert empty tree. Add nodes.");
        } else {
            List<Node<Int32>> nodes = tree.ExportBST();
            BinarySearchTree<Int32> treeCopy = new BinarySearchTree<Int32>(nodes[0].value);
            for (int i = 1; i < nodes.Count; i++) {
                treeCopy.Insert(nodes[i].value);
            }
            treeCopy.BuildTree();
            treeCopy.ConvertToThreaded();
            PrintTreeThreaded(treeCopy);
        }
        WaitKey();
    }

    void InOrderThreaded() {
                Console.Clear();
        if (tree == null) {
            Console.WriteLine("Can't convert empty tree. Add nodes.");
        } else {
            List<Node<Int32>> nodes = tree.ExportBST();
            BinarySearchTree<Int32> treeCopy = new BinarySearchTree<Int32>(nodes[0].value);
            for (int i = 1; i < nodes.Count; i++) {
                treeCopy.Insert(nodes[i].value);
            }

            treeCopy.BuildTree();
            treeCopy.ConvertToThreaded();
            PrintTreeListInt(treeCopy.InOrderThreaded(treeCopy.GetRoot()));
        }
        WaitKey();
    }

    void PrintTreeListInt<T>(List<T> list) {
        list.ForEach(delegate(T value){
            Console.Write($"{value} ");
        });
        Console.WriteLine();
    }

    void PrintTree() {
        Console.Clear();
        PrintTreeRec(tree!.GetRoot(), "", true);
        Console.WriteLine();
        WaitKey();
    }

    void PrintTreeRec(Node<Int32>? tree, String indent, bool last) {
        Console.WriteLine();
        String value = "";
        if (tree != null)
            value = tree.value.ToString();
            
        if(last) 
            Console.Write(indent + "└─ " + value);
        else
            Console.Write(indent + "├─ " + value);
        indent += last ? "   " : "│  ";

        if(tree == null)
            return;

        PrintTreeRec(tree.left, indent, false);
        PrintTreeRec(tree.right, indent, true);
            

        // if (tree.left != null && tree.right != null) {
        //     PrintTreeRec(tree.left, indent, false);
        //     PrintTreeRec(tree.right, indent, true);
        //     return;
        // }

        // if (tree.left != null && tree.right == null) {
        //     PrintTreeRec(tree.left, indent, true);
        //     return;
        // }
            
        // if (tree.left == null && tree.right != null) {
        //     PrintTreeRec(tree.right, indent, true);
        //     return;
        // }

    }

    void PrintTreeThreaded(BinarySearchTree<Int32> tree) {
        if (tree == null) {
            Console.WriteLine("Can't thread an empty tree. Add nodes.");
            WaitKey();
            return;
        }
        Console.Clear();
        // PrintTreeListInt(tree.InOrderThreaded(tree.GetRoot()));
        Console.WriteLine();
        Stack<Node<Int32>> preds = new Stack<Node<int>>();
        PrintTreeRecThreaded(tree.GetRoot(), "", true, preds);
        Console.WriteLine();
    }

    void PrintTreeRecThreaded(Node<Int32>? tree, String indent, bool last, Stack<Node<Int32>> preds) {
        Console.WriteLine();
        String value = "";
        if (tree != null)
            value = tree.value.ToString();

        if(last) 
            Console.Write(indent + "└─ " + value);
        else
            Console.Write(indent + "├─ " + value);
        indent += last ? "   " : "│  ";

        if (tree == null)
            return;

        if (tree.left == null && tree.right != null && tree.IsThreaded()) {
            if (preds.Count != 0)
                Console.Write($" ({preds.Pop().value})");
            // PrintTreeRecThreaded(tree.right, indent, true, preds);
            return;
        }

        if (tree.left != null && tree.right != null)
            preds.Push(tree);

        PrintTreeRecThreaded(tree.left, indent, false, preds);
        PrintTreeRecThreaded(tree.right, indent, true, preds);


        // if (tree.left != null && tree.right != null) {
        //     preds.Push(tree);
        //     PrintTreeRecThreaded(tree.left, indent, false, preds);
        //     PrintTreeRecThreaded(tree.right, indent, true, preds);
        //     return;
        // }

        // if (tree.left != null && tree.right == null) {
        //     PrintTreeRecThreaded(tree.left, indent, true, preds);
        //     return;
        // }

        // if (tree.left == null && tree.right != null && !tree.IsThreaded()) {
        //     // if (preds.Count != 0)
        //     //     Console.Write($" ({preds.Depreds().value})");
        //     PrintTreeRecThreaded(tree.right, indent, true, preds);
        //     return;
        // }
            
        
    }

    void WaitKey() {
        Console.WriteLine("Press any character to continue.");
        Console.ReadKey();
    }


}