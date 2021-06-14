using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// returns created and uploaded pdf file with virtual path.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>

        string TransferPdf<T>(List<T> list) where T:class,new();

        /// <summary>
        /// Returns excel file by byte array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] TransferExcel<T>(List<T> list) where T : class, new();
    }
}
