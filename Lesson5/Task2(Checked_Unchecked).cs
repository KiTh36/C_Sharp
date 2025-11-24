public static class OverflowDemo
{
    public static int AddChecked(int a, int b)
    {
        checked
        {
            return a + b; 
        }
    }

    public static int AddWrapped(int a, int b)
    {
        unchecked
        {
            return a + b; 
        }
    }
}

//--------Тести-----

[TestFixture]
public class OverflowDemoTests
{
  [Test]
   public void AddChecked_Overflow_Throws()
    {
        Assert.Throws<OverflowException>(() =>
        {
            OverflowDemo.AddChecked(int.MaxValue, 1);
        });
    }
    
    [Test]
    public void AddChecked_NoOverflow_ReturnsCorrect()
    {
        Assert.AreEqual(10, OverflowDemo.AddChecked(7, 3));
    }
}


 