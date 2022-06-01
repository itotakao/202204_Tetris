using UnityEngine;

/// <summary>
/// アルゴリズムを実装するクラスの基底クラス
/// </summary>
abstract class Strategy
{
    public abstract void AlgorithmInterface();
}

/// <summary>
/// アルゴリズムAを実装しているクラス
/// </summary>
class ConcreteStrategyA : Strategy
{
    public override void AlgorithmInterface()
    {
        Debug.Log("アルゴリズムA");
    }
}

/// <summary>
/// アルゴリズムBを実装しているクラス
/// </summary>
class ConcreteStrategyB : Strategy
{
    public override void AlgorithmInterface()
    {
        Debug.Log("アルゴリズムB");
    }
}

/// <summary>
/// アルゴリズムCを実装しているクラス
/// </summary>
class ConcreteStrategyC : Strategy
{
    public override void AlgorithmInterface()
    {
        Debug.Log("アルゴリズムC");
    }
}

/// <summary>
/// アルゴリズムの制御情報を持つクラス（状況に応じて異なる動作を行う）
/// ConcreteStrategy　を指定して作成し、Strategyオブジェクトへの参照を保持する
/// </summary>
class Context
{
    private Strategy _strategy;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Context(Strategy strategy)
    {
        this._strategy = strategy;
    }

    /// <summary>
    /// 実際に外部から使うメソッドはコレ
    /// </summary>
    public void ContextInterface()
    {
        _strategy.AlgorithmInterface();
    }
}

public class StrategyTest : MonoBehaviour
{
    private void Start()
    {
        Context context;

        context = new Context(new ConcreteStrategyA());
        context.ContextInterface();                     //アルゴリズムA

        context = new Context(new ConcreteStrategyB());
        context.ContextInterface();                     //アルゴリズムB

        context = new Context(new ConcreteStrategyC());
        context.ContextInterface();                     //アルゴリズムC
    }
}