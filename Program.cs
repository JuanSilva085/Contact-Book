using System;

  public class Contato
  {
    public Contato(string name, int phone, string email)
    {
        Name = name;
        Phone = phone;
        Email = email;
    }
      
      public string Name { get; set; } 
      public int Phone { get; set; }
      public string Email { get; set; } 
}
public class Agenda
 {
    private List<Contato> contatos = new List<Contato>();

    public void Adicionar (Contato contato)
    {
        contatos.Add(contato);
    }

    //método buscar contato

    public Contato BuscarContato(string nome)
    {
        return contatos.FirstOrDefault(contacto => contacto.Name == nome);
    }

    //método buscar indice

    public int BuscarIndice(string nome)
    {
        return contatos.FindIndex(contacto => contacto.Name == nome);
    }


    public void Editar(int index, string newName, string newPhone, string newEmail)
    {
        
        if(index >= 0 && index < contatos.Count) 
        {
            contatos[index].Name = newName;
            contatos[index].Phone = newPhone;
            contatos[index].Email = newEmail;
            Console.WriteLine("Contato atualizado.");
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }

    public void Excluir(string nome)
    {
        var encontraContato = contatos.FirstOrDefault(contacto => contacto.Name == nome);
        if(encontraContato != null)
        {
            contatos.Remove(encontraContato);
        }
        else
        {
            Console.WriteLine("Contato não encontrado");
        }
    }

    public void ListarContatos()
    {
        foreach (var contato in contatos) 
        {
            Console.WriteLine($"Lista de contatos: \nNome: {contato.Name}, \nEmail: {contato.Email} \nTelefone: {contato.Phone}");
        }
    }
 }

//MENU

class Menu
{
    static void Main()
    {
        Agenda agenda = new Agenda();

        while (true)
        {
            Console.WriteLine("Olá, o que deseja fazer?" +
               "\n1- Adicionar um contato " +
               "\n2- Editar um contato" +
               "\n3- Excluir um contato " +
               "\n4- Listar contato");
            int opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Escreva o nome");
                    var nome = Console.ReadLine();


                    //telefone
                    Console.WriteLine("Escreva o telefone (Apenas números)");

                    var telefone; 
                    while(!int.TryParse(Console.ReadLine(), out telefone))
                    {
                        Console.WriteLine("Inválido");    //para garantir que não o programa não quebre
                    }
                    
                    //email
                    Console.WriteLine("Escreva o e-mail");
                    var email = Console.ReadLine();

                    Contato novoContato = new Contato(nome, telefone, email);
                    agenda.Adicionar(novoContato);
                    break;

                case 2:
                    Console.WriteLine("Digite o nome do contato que desejas editar:");
                    var nomeEdit = Console.ReadLine();
                    Contato contatoEdit = agenda.BuscarContato(nomeEdit); //buscar contato pelo nome
                  

                    if (contatoEdit != null)
                    {
                        int index = agenda.BuscarIndice(nomeEdit); //index buscar indice

                        Console.WriteLine("Digite o novo nome:");
                        var newName = Console.ReadLine();

                        Console.WriteLine("Digite o novo telefone");
                        int newPhone;
                        while (!int.TryParse(Console.ReadLine(), out newPhone))
                        {
                            Console.WriteLine("Inválido. Digite um número válido");
                        }

                        Console.WriteLine("Digite um novo e-mail:");
                        var newEmail = Console.ReadLine();
                        agenda.Editar(index, newName, newPhone, newEmail);
                    }
                    else
                    {
                        Console.WriteLine("Contato não encontrado.");
                    }
                    break;

                case 3:
                    Console.WriteLine("Qual contato você deseja excluir?");
                    var excluirContato = Console.ReadLine();
                    agenda.Excluir(excluirContato);
                    break;

                case 4:
                    Console.WriteLine("Listar contatos");
                    agenda.ListarContatos();
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

    }
}
