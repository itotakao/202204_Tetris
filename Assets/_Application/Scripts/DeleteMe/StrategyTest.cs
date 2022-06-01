using UnityEngine;

/// <summary>
/// �A���S���Y������������N���X�̊��N���X
/// </summary>
abstract class Strategy
{
    public abstract void AlgorithmInterface();
}

/// <summary>
/// �A���S���Y��A���������Ă���N���X
/// </summary>
class ConcreteStrategyA : Strategy
{
    public override void AlgorithmInterface()
    {
        Debug.Log("�A���S���Y��A");
    }
}

/// <summary>
/// �A���S���Y��B���������Ă���N���X
/// </summary>
class ConcreteStrategyB : Strategy
{
    public override void AlgorithmInterface()
    {
        Debug.Log("�A���S���Y��B");
    }
}

/// <summary>
/// �A���S���Y��C���������Ă���N���X
/// </summary>
class ConcreteStrategyC : Strategy
{
    public override void AlgorithmInterface()
    {
        Debug.Log("�A���S���Y��C");
    }
}

/// <summary>
/// �A���S���Y���̐���������N���X�i�󋵂ɉ����ĈقȂ铮����s���j
/// ConcreteStrategy�@���w�肵�č쐬���AStrategy�I�u�W�F�N�g�ւ̎Q�Ƃ�ێ�����
/// </summary>
class Context
{
    private Strategy _strategy;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public Context(Strategy strategy)
    {
        this._strategy = strategy;
    }

    /// <summary>
    /// ���ۂɊO������g�����\�b�h�̓R��
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
        context.ContextInterface();                     //�A���S���Y��A

        context = new Context(new ConcreteStrategyB());
        context.ContextInterface();                     //�A���S���Y��B

        context = new Context(new ConcreteStrategyC());
        context.ContextInterface();                     //�A���S���Y��C
    }
}