
using System.Collections.Generic;

abstract class Line
{
    protected int start_x, start_y, length;
    /*protected char theCharacter
    {
        get { return theCharacter; }
        set { theCharacter = value; }
    }*/
    protected char theCharacter;
    public char GetCharacter()
    {
        return theCharacter;
    }
    public Line(int start_x, int start_y, int length)
    {
        this.start_x = start_x;
        this.start_y = start_y;
        this.length = length;
    }

    public abstract bool onLine(int x, int y);

}

class HorizontalLine:Line
{
    public HorizontalLine(int start_x, int start_y, int length) : base(start_x, start_y, length)
    {
        this.theCharacter = '-';

    }

   
    public override bool onLine(int x, int y)
    {
        if(x==start_x && y>=start_y && y<=start_y+length-1)
        {
            return true;
        }
     
        else
        {
            return false;
        }

    }
}

class VerticalLine:Line
{
    public VerticalLine(int start_x, int start_y, int length) : base(start_x, start_y, length)
    {
        this.theCharacter = '|';
    }

    public override bool onLine(int x, int y)
    {
        if (y == start_y && x >= start_x && x <= start_x + length - 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}

class FakeCharacter
{
    private static int size;

    private char[,] FakeCharsArray;

    List<Line> FakeCharsList = new List<Line>();
    public FakeCharacter(int size, int no_paths)
    {
        
        FakeCharacter.size = size;
        FakeCharsArray = new char[size, size];
        makePaths(no_paths);
        for(int i=0;i<FakeCharsArray.GetLength(0);i++)
        {
            for(int j=0;j<FakeCharsArray.GetLength(1); j++)
            {
                foreach (var x in FakeCharsList)
                {
                    if (x.onLine(i, j))
                    {
                        FakeCharsArray[i, j] = x.GetCharacter();
                    }
                }
            }
        }
        addCircles(4);
    }

    public void makePaths(int no_paths)
    {
        Random rnd=new Random();
        int Vertical_Horizontal;
        for(int i=0;i<no_paths;i++)
        {
            int start_x = rnd.Next(0, size);
            int start_y = rnd.Next(0, size);
            int length = rnd.Next(0, size);
            Vertical_Horizontal = rnd.Next(0, 2);
            if(Vertical_Horizontal==0)
            {
                HorizontalLine H = new HorizontalLine(start_x, start_y, length);
                FakeCharsList.Add(H);

            }
            else 
            {

                VerticalLine V = new VerticalLine(start_x, start_y, length);
                FakeCharsList.Add(V);
            }
        }
    }
    public void addCircles(int no_circles)
    {
        Random rnd = new Random();
        for (int i = 0; i < no_circles; i++)
        {
            int x = rnd.Next(0, size);
            int y = rnd.Next(0, size);
            FakeCharsArray[x, y] = 'o';
        } 
    }
    public void printCharacter()
    {
        for(int i=0;i<size;i++)
        {
            for(int j=0;j<size;j++)
            {
                if (FakeCharsArray[i,j]=='\u0000')
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(FakeCharsArray[i,j]);

                }
            }
            Console.WriteLine();
        }
    }
    
}
 
class main_
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            FakeCharacter myChar = new FakeCharacter(5, 10);
            myChar.printCharacter();
            Console.WriteLine("~~~~~~~~~~");
        }
    }
}











