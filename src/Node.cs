public class Node<T> where T: IComparable {
        public T value;
        public Node<T>? left;
        public Node<T>? right;
        private bool isThreadedLeft;
        private bool isThreadedRight;
        public Node(T value) {
            this.value = value;
            this.left = null;
            this.right = null;
            this.isThreadedLeft = false;
            this.isThreadedRight = false;
        }
    }