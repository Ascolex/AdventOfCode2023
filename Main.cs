using System;
using System.Collections.Generic; 

public class Program 
{
  public static int[] wins = new int[213];
  public static int[] totalWins = new int[wins.Length];
  public class cards
  {
    public int cardNum;
    public int winnings;
    public cards(int index)
    {
      cardNum = index;
      winnings = Program.wins[index];
    }
  }
  public static void Main(string[] args) 
  {
    string input = "10/7/4/8/7/10/7/10/3/1/0/0/9/10/1/7/0/1/4/4/3/1/1/0/10/10/10/10/3/10/10/0/5/0/7/7/3/2/5/1/0/1/2/0/0/6/10/10/4/7/1/0/4/1/0/6/2/4/5/3/5/2/1/0/1/0/8/10/9/10/10/10/3/10/4/6/10/4/0/7/0/3/1/0/2/3/1/1/0/7/10/6/9/5/10/4/4/9/6/3/3/2/0/1/1/2/0/2/0/0/0/6/8/4/3/10/0/7/8/3/5/7/2/6/0/0/3/0/1/0/10/7/6/5/4/1/1/7/5/3/4/3/4/6/2/2/5/0/2/0/2/1/0/0/10/3/9/8/4/3/4/5/7/6/3/1/1/3/2/0/0/10/10/10/3/10/10/9/10/10/10/5/7/9/5/7/0/7/6/4/1/4/0/2/1/0/0/10/3/9/4/3/4/7/2/0/4/2/1/2/2/1/0/";

   
    for(int i = 0; i<wins.Length; i++)
    {
      string temp = "";
      while(input.Substring(0,1) != "/")
      {
        temp = temp + input.Substring(0,1);
        input = input.Substring(1,input.Length-1);
      }
      wins[i] = Int32.Parse(temp);
      input = input.Substring(1,input.Length-1);
    }
    
    
    for(int i = wins.Length -1 ; i>=0; i--)
    {
      int count = 0;
      List<cards> wonCards = new List<cards>();
      wonCards.Add(new cards(i));
      while(wonCards.Count > 0)
      {
        cards c = wonCards[0];
        for(int j = c.cardNum + 1; j < c.cardNum + 1 + c.winnings && j <= wins.Length; j++)
        {
          if(totalWins[j] != 0)
          {
            count += totalWins[j];
          }
          else
            wonCards.Add(new cards(j));
        }
        wonCards.Remove(c);
        count++;
      }
      totalWins[i] = count;
    
    }

    int sum = 0;
    foreach (int a in totalWins)
    {
      sum += a;
    }
    Console.WriteLine(sum);
  }
}