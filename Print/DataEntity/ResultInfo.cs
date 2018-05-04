using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    /// <summary>服务基础返回模型
    /// </summary>
    public class ResultInfo
    {
        /// <summary>是否成功
        /// </summary>
        public Boolean IsSuccess { get; set; }

        /// <summary>执行结束返回消息
        /// </summary>
        public String Msg { get; set; }

        public ResultInfo() { }

        /// <summary>失败
        /// </summary>
        /// <param name="msg">定义失败信息</param>
        /// <returns></returns>
        public static ResultInfo Fail(String msg)
        {
            return new ResultInfo
            {
                IsSuccess = false,
                Msg = msg
            };
        }

        /// <summary>成功 
        /// </summary>
        /// <param name="msg">可定义成功信息</param>
        /// <returns></returns>
        public static ResultInfo Success(String msg)
        {
            return new ResultInfo
            {
                IsSuccess = true,
                Msg = msg
            };
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static ResultInfo Success()
        {
            return Success(string.Empty);
        }
    }

    /// <summary>服务返回基础模型
    /// </summary>
    public class ResultInfo<T> : ResultInfo
    {
        /// <summary>数据
        /// </summary>
        public T Data { get; set; }

        public ResultInfo() { }

        /// <summary>失败
        /// </summary>
        /// <param name="msg">定义失败信息</param>
        /// <returns></returns>
        public new static ResultInfo<T> Fail(String msg)
        {
            return new ResultInfo<T>
            {
                IsSuccess = false,
                Msg = msg
            };
        }
        /// <summary>失败 
        /// </summary>
        /// <param name="data">要返回的数据泛型</param>
        /// <param name="msg">定义失败信息</param>
        /// <returns></returns>
        public static ResultInfo<T> Fail(T data, String msg)
        {
            return new ResultInfo<T>
            {
                IsSuccess = false,
                Msg = msg,
                Data = data
            };
        }

        /// <summary>成功 
        /// </summary>
        /// <param name="data">要返回的数据泛型</param>
        /// <param name="msg">可定义成功信息</param>
        /// <returns></returns>
        public static ResultInfo<T> Success(T data, String msg)
        {
            return new ResultInfo<T>
            {
                IsSuccess = true,
                Msg = msg,
                Data = data
            };
        }

        /// <summary>成功 
        /// </summary>
        /// <param name="data">要返回的数据泛型</param>
        /// <returns></returns>
        public static ResultInfo<T> Success(T data)
        {
            return Success(data, string.Empty);
        }
    }
}
