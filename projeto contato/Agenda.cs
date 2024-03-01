using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

//🅲🅻🅰🆂🆂🅴 🅰🅶🅴🅽🅳🅰
namespace projeto_contato
{
    public class Agenda
    {
        private List<Contato> contatos = new List<Contato>();
        private string arquivo = "contatos.json";

        public void AdicionarContato(Contato contato)
        {
            contatos.Add(contato);
        }

        public void ListarContatos()
        {
            foreach (var contato in contatos)
            {
                Console.WriteLine(contato);
            }
        }

        public Contato BuscarContato (string termo)
        {
            return contatos.Find(contato =>
              contato.Nome.Equals(termo, StringComparison.OrdinalIgnoreCase) ||
              contato.Telefone.Equals(termo, StringComparison.OrdinalIgnoreCase) ||
              contato.Email.Equals(termo, StringComparison.OrdinalIgnoreCase) );
        }

        public void EditarContato(string termo, Contato novoContato)
        {
            Contato contato = BuscarContato(termo);

            if (contato != null)
            {
                int index = contatos.IndexOf(contato);
                contatos[index] = novoContato;
            }

            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        public void ExcluirContato(string termo)
        {
            Contato contato = BuscarContato(termo);

            if(contato != null)
            {
                contatos.Remove(contato);
                Console.WriteLine("Contato excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        public void SalvarContatos()
        {
            string json = JsonConvert.SerializeObject(contatos);
            File.WriteAllText(arquivo, json);
        }

        public void CarregarContatos()
        {
            if (File.Exists(arquivo))
            {
                string json = File.ReadAllText(arquivo);
                contatos = JsonConvert.DeserializeObject<List<Contato>>(json);
            }
        }
    }
}
