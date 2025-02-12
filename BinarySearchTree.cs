using System;

class BinarySearchTree
{
    private class Node
    {
        public string Key { get; set; }
        public string Data { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public Node(string key, string data, Node left = null, Node right = null)
        {
            Key = key;
            Data = data;
            LeftChild = left;
            RightChild = right;
        }

        public override string ToString()
        {
            return "{" + Key + ", " + Data + "}";
        }
    }

    private Node Root { get; set; }

    public BinarySearchTree()
    {
        Root = null; // Initially, the tree is empty
    }

    public bool IsEmpty()
    {
        return Root == null;
    }

    public (string data, string key) RootNode()
    {
        if (IsEmpty())
        {
            throw new Exception("No root node in empty tree");
        }
        return (Root.Data, Root.Key);
    }

    private (Node node, Node parent) Find(string goal)
    {
        Node current = Root; // Start at root
        Node parent = null;  // Parent of current node

        while (current != null && goal != current.Key)
        {
            parent = current; // One level down
            current = goal.CompareTo(current.Key) < 0 ? current.LeftChild : current.RightChild;
        }

        return (current, parent);
    }

    public string Search(string goal)
    {
        var (node, _) = Find(goal);
        return node != null ? node.Data : null;
    }

    public bool Insert(string key, string data)
    {
        var (node, parent) = Find(key);

        if (node != null)
        {
            node.Data = data; // Update node's data
            return false;     // Return flag for no insertion
        }

        if (parent == null)
        {
            Root = new Node(key, data); // For empty trees, insert new node
        }
        else if (key.CompareTo(parent.Key) < 0)
        {
            parent.LeftChild = new Node(key, data); // Insert left
        }
        else
        {
            parent.RightChild = new Node(key, data); // Insert right
        }

        return true;
    }

    public void InOrderTraverse(Action<Node> function = null)
    {
        function = function ?? (n => Console.WriteLine(n));
        InOrderTraverse(Root, function);
    }

    private void InOrderTraverse(Node node, Action<Node> function)
    {
        if (node != null)
        {
            InOrderTraverse(node.LeftChild, function); // Process left subtree
            function(node); // Visit node (print)
            InOrderTraverse(node.RightChild, function); // Process right subtree
        }
    }

    public (string key, string data) MinNode()
    {
        if (IsEmpty())
        {
            throw new Exception("No minimum node in empty tree");
        }

        Node node = Root; // Start at root
        while (node.LeftChild != null) // While has a left child
        {
            node = node.LeftChild; // Follow left child reference
        }

        return (node.Key, node.Data);
    }

    public void Print(int indentBy = 4)
    {
        PrintTree(Root, "ROOT:    ", "", indentBy);
    }

    private void PrintTree(Node node, string nodeType, string indent, int indentBy)
    {
        if (node != null)
        {
            PrintTree(node.RightChild, "RIGHT: ", indent + new string(' ', indentBy), indentBy); // Print the right subtree
            Console.WriteLine(indent + nodeType + node); // Print this node
            PrintTree(node.LeftChild, "LEFT: ", indent + new string(' ', indentBy), indentBy); // Print the left subtree
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree tree = new BinarySearchTree(); // Start with an empty tree
        tree.Insert("Don", "1974 1"); // Insert some data
        tree.Insert("Herb", "1975 2");
        tree.Insert("Ken", "1979 1");
        tree.Insert("Ivan", "1988 1");
        tree.Insert("Raj", "1994 1");
        tree.Insert("Amir", "1996 1");
        tree.Insert("Adi", "2002 3");
        tree.Insert("Ron", "2002 3");
        tree.Insert("Fran", "2006 1");
        tree.Insert("Vint", "2006 2");
        tree.Insert("Tim", "2016 1");

        tree.Print();

        Console.WriteLine("Search for 'Raj': " + tree.Search("Raj"));
        Console.WriteLine("Minimum node: " + tree.MinNode());

        Console.WriteLine("In-order traversal:");
        tree.InOrderTraverse();
    }
}