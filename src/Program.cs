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
4. Add threading;
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
                    AddThreading();
                    break;
                }
                case "0": {
                    doContinue = false;
                    break;
                }
                default: {
                    doContinue = false;
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
            tree.Add(value);
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
                tree.Remove(value);
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

    // TODO: Traverse InOrder
    void TraverseInOrder() {

    }

    // TODO: Traverse PreOrder
    void TraversePreOrder() {
        
    }

    // TODO: Traverse PostOrder
    void TraversePostOrder() {
        
    }

    // TODO: add threading
    void AddThreading() {

    }

    void WaitKey() {
        Console.WriteLine("Press any character to continue.");
        Console.ReadKey();
    }
}