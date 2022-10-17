using System;
class App {
    private BinarySearchTree<Int32>? tree;
    public void chooseAction() {

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
                    addNode();
                    break;
                }
                case "2": {
                    removeNode();
                    break;
                }
                case "3": {
                    traverse();
                    break;
                }
                case "3.1": {
                    traverseInOrder();
                    break;
                }
                case "3.2": {
                    traversePreOrder();
                    break;
                }
                case "3.3": {
                    traversePostOrder();
                    break;
                }
                case "4": {
                    addThreading();
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

    // TODO: add node
    void addNode() {
        String text = 
@"Enter value of new node:
> ";
        Int32 value = readInt32(text);
        if (tree == null) {
            tree = new BinarySearchTree<Int32>(value);
        } else {
            tree.add(value);
        }
    }

    void removeNode() {
        if (tree == null) {
            Console.WriteLine("There are no nodes in tree. Add nodes first.");
            waitKey();
        } else {
            String text = 
@"Enter value of node to remove
> ";        
            Int32 value = readInt32(text);
            if (!tree.contains(value)) {
                Console.WriteLine("There are no nodes with such value.");
                waitKey();
            } else {
                tree.remove(value);
            }
        }
    }

    Int32 readInt32(String text) {
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
    void traverse() {
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
                    traverseInOrder();
                    doContinue = false;
                    break;
                }
                case "2": {
                    traversePreOrder();
                    doContinue = false;
                    break;
                }
                case "3": {
                    traversePostOrder();
                    doContinue = false;
                    break;
                }
                default: {
                    break;
                }
            }
        }
    }

    // TODO: traverse InOrder
    void traverseInOrder() {

    }

    // TODO: traverse PreOrder
    void traversePreOrder() {
        
    }

    // TODO: traverse PostOrder
    void traversePostOrder() {
        
    }

    // TODO: add threading
    void addThreading() {

    }

    void waitKey() {
        Console.WriteLine("Press any character to continue.");
        Console.ReadKey();
    }
}