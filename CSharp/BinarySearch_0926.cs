internal class Program
{
    private static void Main(string[] args)
    {

        List<int> li=new List<int>()
        {15,20,25,35,45,55,60,75,85,90};
        Console.Write("찾는 숫자를 입력(15,20,25,35,45,55,60,75,85,90): ");
        int number=int.Parse(Console.ReadLine());
        int left = 0;
        int right = li.Count - 1;
        int mid;
        while (left<=right)
        {
            mid= (left+right)/2;
            if (li[mid] < number)
                left = mid + 1;
            else if (li[mid] > number)
                right = mid - 1;
            else
            {
                Console.WriteLine("{0}가 배열[{1}]에 있다", number, mid);
                break;
            }
        }

        if (left > right)
            Console.WriteLine("{0}는 배열에 없음", number) ;
    }
}
