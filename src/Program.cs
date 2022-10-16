// See https://aka.ms/new-console-template for more information
using System;
class App {
    static public int Main(String[] args) {

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
        return 0;
    }

    // TODO: add node
    static void addNode() {

    }

    // TODO: remove node
    static void removeNode() {

    }


    // Pick what type of traversion to show.
    static void traverse() {
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
    static void traverseInOrder() {

    }

    // TODO: traverse PreOrder
    static void traversePreOrder() {
        
    }

    // TODO: traverse PostOrder
    static void traversePostOrder() {
        
    }

    // TODO: add threading
    static void addThreading() {

    }
}