class BinarySearchTree<T> where T: IComparable {
    Node<T> root;

    public BinarySearchTree(T value) {
        this.root = new Node<T>(value);
    }

    public Node<T> GetRoot() {
        return root;
    }
    
    public void Insert(T value) { 
        root = InsertRec(root, value); 
    }
    private Node<T> InsertRec(Node<T>? root, T value)
    {
 
        // If the tree is empty,
        // return a new node
        if (root == null) {
            root = new Node<T>(value);
            return root;
        }
 
        // Otherwise, recur down the tree
        if (Compare(value, root.value) == -1)
            root.left = InsertRec(root.left, value);
        else if (Compare(value, root.value) == 1)
            root.right = InsertRec(root.right, value);
 
        // Return the (unchanged) node pointer
        return root;
    }

    

    // x > y return 1
    // x < y return -1
    // x == y return 0
    private int Compare(T x, T y) {
        if (EqualityComparer<T>.Default.Equals(x, y))
            return 0;
        if (System.Collections.Generic.Comparer<T>.Default.Compare(x,y) < 0) 
            return -1;
        if (System.Collections.Generic.Comparer<T>.Default.Compare(x,y) > 0) 
            return 1;

        return 0;
    }

    // TODO: remove node
    public void Remove(T value) {
    
    }

    // Check if node is in tree
    public bool Contains(T value) {
        return ContainsUtil(root, value);
    }

    private bool ContainsUtil(Node<T>? root, T value) {
        if (root == null)
            return false;

        if (Compare(value, root.value) == 1)
            return ContainsUtil(root.right, value);
        else if (Compare(value, root.value) == -1)
            return ContainsUtil(root.left, value);
        else if (Compare(value, root.value) == 0)
            return true;
        else
            return false;
    }

    // TODO: make long variations with threaded options.
    public List<T> InOrder(Node<T>? root) {
        if (root == null)
            return new List<T>();

        List<T> result = new List<T>();
        List<T> listLeft = InOrder(root.left);
        List<T> listRight = InOrder(root.right);
    
        result.AddRange(listLeft);
        result.Add(root.value);
        result.AddRange(listRight);

        return result;
    }

    public List<T> PreOrder(Node<T>? root) {
        if (root == null)
            return new List<T>();

        List<T> listLeft = PreOrder(root.left);
        List<T> listRight = PreOrder(root.right);
        List<T> result = new List<T>();

        result.Add(root.value);
        result.AddRange(listLeft);
        result.AddRange(listRight);

        return result;
    }

    public List<T> PostOrder(Node<T>? root) {
        if (root == null)
            return new List<T>();

        List<T> listLeft = PostOrder(root.left);
        List<T> listRight = PostOrder(root.right);
        List<T> result = new List<T>();

        result.AddRange(listLeft);
        result.AddRange(listRight);
        result.Add(root.value);

        return result;
    }

    public List<T> TraversalLong(Node<T>? root) {
        List<T> result = new List<T>();
        
        if (root == null) {
            result.Add(default(T)!);
            return result;
        }
            
        List<T> listLeft = InOrder(root.left);
        List<T> listRight = InOrder(root.right);
    
        result.Add(root.value);
        result.AddRange(listLeft);
        result.Add(root.value);
        result.AddRange(listRight);
        result.Add(root.value);

        return result;
    }

    private void StoreNodesList(Node<T> root, List<Node<T>> nodes) {
        // Base case
        if (root == null) {
            return;
        }
 
        // Remove threaded interactions
        root.SetThreaded(false);

        // Store nodes in Inorder (which is sorted
        // order for BST)
        if(root.left != null)
            StoreNodesList(root.left, nodes);
        nodes.Add(root);
        if(root.right != null)
            StoreNodesList(root.right, nodes);
    }
 
    /* Recursive function to construct binary tree */
    private Node<T>? BuildTreeUtil(List<Node<T>> nodes, int start, int end) {
        // base case
        if (start > end) {
            return null;
        }
 
        /* Get the middle element and make it root */
        int mid = (start + end) / 2;
        Node<T> node = nodes[mid];
 
        /* Using index in Inorder traversal, construct
           left and right subtress */
        node.left = BuildTreeUtil(nodes, start, mid - 1);
        node.right = BuildTreeUtil(nodes, mid + 1, end);
 
        return node;
    }
 
    // This functions converts an unbalanced BST to
    // a balanced BST
    public void BuildTree() {
        // Store nodes of given BST in sorted order
        List<Node<T>> nodes = new List<Node<T>>();
        StoreNodesList(root, nodes);
 
        // Constructs BST from nodes[]
        int n = nodes.Count;
        root = BuildTreeUtil(nodes, 0, n - 1)!;
    }

    public void ConvertToThreaded() {
        Queue<Node<T>>? queue = new Queue<Node<T>>();
        StoreNodesQueue(root, ref queue);
        ConvertToThreadedUtil(root, ref queue);
    }

    // Put nodes inOrder in queue
    void StoreNodesQueue(Node<T>? root, ref Queue<Node<T>> queue) {
        if (root == null)
            return;
        if (root.left != null)
            StoreNodesQueue(root.left, ref queue);
        queue.Append(root);
        if (root.right != null)
            StoreNodesQueue(root.right, ref queue);
    }

    void ConvertToThreadedUtil(Node<T> root, ref Queue<Node<T>> queue) {
        if (root == null)
            return;

        if (root.left != null)
            ConvertToThreadedUtil(root.left, ref queue);
        
        queue.Dequeue();

        if (root.right != null)
            ConvertToThreadedUtil(root.right, ref queue);
        else {
            root.right = queue.First();
            root.SetThreaded(true);
        }
    }
}