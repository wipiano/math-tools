namespace MathTools.Algebra;

public partial class EntryPoint
{
    /// <summary>
    /// オイラー関数の値を求める．
    /// </summary>
    /// <param name="n"></param>
    /// <param name="showDetails"></param>
    [Command("euler")]
    public void EulersTotientFunction([Option(0)]int n, [Option("d")] bool showDetails)
    {
        if (n < 1)
        {
            Console.Error.WriteLine("1以上の整数を指定してください");
            return;
        }

        int count = 0;

        Parallel.ForEach(Enumerable.Range(2, n - 1), x =>
        {
            if (IsRelativelyPrime(x, n)) Interlocked.Increment(ref count);
        });

        Console.WriteLine(count + 1);
    }

    /// <summary>
    /// 最大公約数をユークリッドの互除法により求める．
    /// </summary>
    /// <returns></returns>
    private int CalcGreatestCommonDivisor(int m, int n)
    {
        if (n == 0) return m;
        return CalcGreatestCommonDivisor(n, m % n);
    }

    /// <summary>
    /// 2つの整数が互いに素であるかを調べる．
    /// </summary>
    private bool IsRelativelyPrime(int x, int y)
    {
        return CalcGreatestCommonDivisor(x, y) == 1;
    }
}
