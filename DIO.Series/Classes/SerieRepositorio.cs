using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void atualizar(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void excluir(int id)
        {
            listaSerie[id].excluir();
        }

        public void inserir(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int proximoId()
        {
            return listaSerie.Count;
        }

        public Serie retornarPorId(int id)
        {
            return listaSerie[id];
        }
    }
}