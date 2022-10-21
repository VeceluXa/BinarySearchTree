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
    Node<T> InsertRec(Node<T>? root, T value)
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

    // TODO: check if node is in tree
    public bool Contains(T value) {
        return CompareEqual(value, root.value);
    }

    public List<T> InOrder(Node<T>? root) {
        if (root == null)
            return new List<T>();

        List<T> listLeft = InOrder(root.left);
        List<T> listRight = InOrder(root.right);
        List<T> result = new List<T>();

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

    public bool CompareEqual(T x, T y) {
        return EqualityComparer<T>.Default.Equals(x, y);
    }

    public virtual void storeBSTNodes(Node<T> root, List<Node<T>> nodes) {
        // Base case
        if (root == null) {
            return;
        }
 
        // Store nodes in Inorder (which is sorted
        // order for BST)
        if(root.left != null)
            storeBSTNodes(root.left, nodes);
        nodes.Add(root);
        if(root.right != null)
            storeBSTNodes(root.right, nodes);
    }
 
    /* Recursive function to construct binary tree */
    public virtual Node<T>? buildTreeUtil(List<Node<T>> nodes, int start, int end) {
        // base case
        if (start > end) {
            return null;
        }
 
        /* Get the middle element and make it root */
        int mid = (start + end) / 2;
        Node<T> node = nodes[mid];
 
        /* Using index in Inorder traversal, construct
           left and right subtress */
        node.left = buildTreeUtil(nodes, start, mid - 1);
        node.right = buildTreeUtil(nodes, mid + 1, end);
 
        return node;
    }
 
    // This functions converts an unbalanced BST to
    // a balanced BST
    public virtual void buildTree() {
        // Store nodes of given BST in sorted order
        List<Node<T>> nodes = new List<Node<T>>();
        storeBSTNodes(root, nodes);
 
        // Constructs BST from nodes[]
        int n = nodes.Count;
        root = buildTreeUtil(nodes, 0, n - 1)!;
    }
}