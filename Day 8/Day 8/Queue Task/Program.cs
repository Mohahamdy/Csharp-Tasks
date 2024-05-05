namespace Queue_Task
{
    class queue <T>
    {
        int front, rear;
        T[] arr;

        public queue(int size=5)
        {
            arr = new T[size];
            front = rear = 0;
        }

        public void Enqueue(T item)
        {
            if (rear < arr.Length)
            {
                arr[rear++] = item;
            }
            else
                throw new Exception("FULL");
        }

        public T Dequeue()
        {
            if (front != rear)
            {
                T firstItem = arr[front];
                for (int i = 0; i < rear; i++)
                {
                    arr[i] = arr[i + 1];
                }
                rear--;
                return firstItem;
            }
            
            return default(T);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //queue<int> q= new queue<int> ();
            
            //q.Enqueue(1);
            //q.Enqueue(2);
            //q.Enqueue(3);
            //q.Enqueue(4);

            //Console.WriteLine(q.Dequeue());
            //Console.WriteLine(q.Dequeue());

            //q.Enqueue(5);
            //q.Enqueue(6);

            //Console.WriteLine(q.Dequeue());

            queue<string> queue = new queue<string>();

            queue.Enqueue("mohamed");
            queue.Enqueue("ahmed");
            queue.Enqueue("ali");
            //queue.Enqueue("ali");
            //queue.Enqueue("ali");
            //queue.Enqueue("ali");

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

        }
    }
}
