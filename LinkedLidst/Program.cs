class LinkedLidst
{
    private int maxSize;
    private int size;
    private string[,] items;
    private int start;
    private int free;
    public LinkedLidst(int maxSize)
    {
        this.maxSize = maxSize;
        items = new string[maxSize,2];
        start = -1;
        free = 0;
        for (int i=0; i<maxSize; i++)
        {
            items[i,1] = (i+1).ToString();
        }
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

    public 
    public boolean add(string value)
    {
        if (maxSize == size)
        {
            return false;
        }
        if (start == -1)
        {
            items[free,0] = value;
            start = free;
            free = int.Parse(items[free,1]);
            items[free,1] = "-1";
            return true;
        }
        char newchar = value[0];
        int new = newchar;
        int next;
        int temp;
        for (int i; i<size, int++)
        {
            if (i==0)
            {
                string first = its[start,0];
                next = int.Parse(items[start,1]);
            }
            else
            {
                string first = items[next,0];
                temp = next;
                next = int.Parse(items[temp,1]);
            }
            char firstchar = first[0];
            int current = firstchar;
            int tempfree;
            if (current < new)
            {
                tempfree = int.Parse(items[free,1]);
                items[free,0] = value;
                items[free,1] = items[temp,1];
                items[temp,1] = free.ToString();
                size += 1;
                free = tempfree;
            }
        }
    }

}