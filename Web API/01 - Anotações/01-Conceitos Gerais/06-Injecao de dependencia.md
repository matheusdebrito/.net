Injeção de Dependência é uma técnica de programação usada para tornar uma classe independente de suas dependências. 
A injeção de dependência (DI) é uma padrão usado para implementar a inversão de controle (IoC) e assim reduzir o acoplamento entre os objetos.
Ao aplicar a injeção de dependência fazemos com que um objeto fornaça as dependências de outro objeto.

Apresentando o problema
````c#
public class Cliente{
    Pedido meuPedido = new Pedido();

    public List<Pedido> ObterPedidos()
    {
        return meuPedido.GetPedidos();
    }
}
````
Nesse exemplo a classe Cliente tem um acoplamento com a classe pedido. A Classe Cliente possui a responsabilidade de saber como criar uma instância de Pedido e depende desta instância. Qualquer mudança feita na classe Pedido afeta a classe Cliente. Esse código viola o princípio SOLID SRP princípio da responsabilidade única. 

Como resolver o problema?

Temos que tirar da classe Cliente a responsabilidade de criar a classe Pedido. Vamos inverter o controle na classe Cliente e tirar dela essa dependência. Vamos passar a responsabilidade de criar a instância de Pedido para outra classe. Esse é o princípio da inversão de controle ou inversão de dependência.

A classe Cliente não deverá depender diretamente da implementação da classe Pedido. Devemos criar uma abstração entre as classes e as classes deverão depender somente desta abstração. Esta abstração poderá ser outra classe, uma interface ou um componente.

````c#
// Abstração: interface
public interface IPedido
{
    List<Pedido> GetPedidos();
}

// Implementação
public class Pedido : IPedido
{
    public int PedidoID { get; set;}
    public int ClientID { get; set;}

    public List<Pedido> GetPedidos()
    {
        var pedidos = new List<Pedido>();
        pedidos.Add(new Pedido { PedidoId = 1, ClientID = 1});
        return pedidos
    }
}

// Classe cliente
public class Cliente
{
    private readonly IPedido pedido;
    
    public Cliente(IPedido pedido)
    {
        this.pedido = pedido;
    }

    public List<Pedido> ObterPedidos()
    {
        return pedido.GetPedidos();
    }
}
````

Agora a classe Cliente não precisa criar uma instância da classe Pedido (não temos mais o operador new).
Ela usa um contrato representado pela interface IPedido que é responsável por retornar uma implementação de Pedido.
A classe Cliente depende agora de uma abstração (IPedido) e não de uma implementação.
Aqui realizamos a inversão de controle, ou seja, agora a responsabilidade de criar uma instância de Pedido foi passada para a interface IPedido