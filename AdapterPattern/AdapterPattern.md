- 适配器模式（Adapter Pattern）是一种结构型设计模式，它将一个类的接口转换成客户端期望的另一种接口，使得原本由于接口不兼容而不能一起工作的类能够协同工作。适配器模式主要用于整合遗留系统或第三方库，其核心思想为“转换接口”。
  
### 适配器模式的核心角色
- 目标(Target)：客户端期望的接口。
- 适配者(Adaptee)：已有的、接口不兼容的类。
- 适配器(Adapter)：实现目标接口，内部包装适配者，并将调用转换成适配者的方法调用。

### 实例：Duck与Turkey

```cs
    public interface IDuck//鸭子接口
    {
        void Quack();
        void Fly();
    }
```
一只Duck应该可以嘎嘎叫`Quack()`以及飞`Fly()`。

```cs
    public interface ITurkey
    {
        void Gobble();
        void Fly();
    }
```
一只Turkey可以咯咯叫`Gobble()`以及飞`Fly()`。

```cs
    class MallardDuck : IDuck
    {
        public void Quack()
        {
            Console.WriteLine("Quack Quack Quack");
        }

        public void Fly()
        {
            Console.WriteLine("Flies 500 Metres");
        }
    }
```
绿头鸭`MallardDuck`继承自`IDuck`接口，并实现`Quack()`和`Fly()`。

```cs
    class WildTurkey : ITurkey
    {
        public void Gobble()
        {
            Console.WriteLine("Gobble Gobble Gobble");
        }

        public void Fly()
        {
            Console.WriteLine("Flies 100 Metres");
        }
    }
```
野火鸡`WildTurkey`同理。

现在我们有一个`Tester`方法需要接受一个`Iduck`类型的对象。如何让这个方法接受一个`turkey`呢？