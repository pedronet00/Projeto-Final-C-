using Repositorio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioCliente
    {

        public bool remover(int id)
        {
            var sucesso = true;

            try
            {

                using (var contexto = new Projeto2022Entities())
                {
                    var obj = (
                        from x in contexto.Cliente
                        where x.Id == id
                        select x
                    ).SingleOrDefault();

                    if(obj != null)
                    {
                        contexto.Cliente.Remove(obj);
                        contexto.SaveChanges();
                    }
                }
            }

            catch(Exception ex)
            {
                sucesso = false;
            }

            return sucesso;
        }
    
        public Cliente recuperarPorId(int id)
        {
            Cliente obj = null;

            try
            {
                using (var contexto = new Projeto2022Entities())
                {

                    obj = (
                        from l in contexto.Cliente
                        where l.Id == id
                        select l
                        ).SingleOrDefault();
                }
            }

            catch (Exception)
            {
                obj = null;
            }

            return obj;
        }


    
        public List<Cliente> listarTodos()
        {
            var lista = new List<Cliente>();

            try
            {

                using (var contexto = new Projeto2022Entities())
                {

                    lista = (
                        from l in contexto.Cliente
                        select l
                    ).ToList();
                }
            }

            catch (Exception)
            {

            }

            return lista;
        }
    
        public bool salvar(Cliente obj)
        {
            var sucesso = true;

            try
            {
                using (var contexto = new Projeto2022Entities())
                {

                    if(obj.Id == 0)
                    {

                        contexto.Cliente.Add(obj);

                    }
                    else
                    {

                        var registro = (
                            from x in contexto.Cliente
                            where x.Id == obj.Id
                            select x
                        ).SingleOrDefault();

                        registro.Nome = obj.Nome;
                    }

                    contexto.SaveChanges();
                }
            }

            catch (Exception)
            {
                sucesso = false;
            }

            return sucesso;
        }
    }

}
