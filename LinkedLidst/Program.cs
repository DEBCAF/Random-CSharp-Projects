class LinkedLidst
{
    private int maxSize;
    private int size;
    private string[] items;
    private int start;
    private int free;
    public LinkedLidst(int maxSize)
    {
        this.maxSize = maxSize;
        items = new string[maxSize];
        start = -1;
        free = 0;
    }

    public boolean isFull()
    {
        if (maxSize == size)
        {
            return true;
        }
        return false;
    }
    class node
    {
        private string data;
        private int pointer;

        public node(string data, int pointer)
        {
            this.pointer = pointer;
            this.data = data;
        }
    }

    public boolean add(string value)
    {
        if 
    }

}