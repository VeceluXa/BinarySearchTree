public class Node<T> where T: IComparable {
        public T value;
        public Node<T>? left;
        public Node<T>? right;
        private bool isThreaded;
        public Node(T value) {
            this.value = value;
            this.left = null;
            this.right = null;
            this.isThreaded = false;
        }

        public void SetThreaded(bool val) {
            isThreaded = val;
        }
    }