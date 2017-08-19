using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Subscriber.Infrastructure.Data.Seedwork {

    /// <summary>
    /// Ajudante de paginação
    /// </summary>
    internal class Pager {

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="rowsPerPage">Quantidade de linhas por página</param>
        /// <param name="currentPage">Página atual</param>
        public Pager(int rowsPerPage, int currentPage = 1) {
            this.Length = rowsPerPage;
            this.StartIndex = --currentPage * this.Length;
        }

        /// <summary>
        /// Quantidade
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Registro inicial
        /// </summary>
        public int StartIndex { get; private set; }

        /// <summary>
        /// Obtem a quantidade de páginas necessárias para exibir todas as linhas
        /// </summary>
        /// <param name="total">Quantidade total de linhas</param>
        /// <param name="rowsPerPage">Quantidade de linhas por página</param>
        /// <returns>Quantidade de páginas necessárias para exibir todas as linhas</returns>
        public static long PageCount(long total, int rowsPerPage) {

            long pageCount = total / rowsPerPage;

            if (total % rowsPerPage > 0) pageCount++;

            return pageCount;
        }
    }
}
