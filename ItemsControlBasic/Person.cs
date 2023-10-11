﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ItemsControlBasic
{
    /// <summary>
    /// 人物を表します。
    /// </summary>
    public class Person
    {
        /// <summary>
        /// 名字を取得または設定します。
        /// </summary>
        public string FamilyName { get; set; }
        /// <summary>
        /// 名前を取得または設定します。
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 氏名を取得します。
        /// </summary>
        public string FullName { get { return this.FamilyName + this.FirstName; } }
        /// <summary>
        /// 性別を取得または設定します。
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// 年齢を取得または設定します。
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 認証済みかどうかを取得または設定します。
        /// </summary>
        public bool IsAuthenticated { get; set; }
    }
}
