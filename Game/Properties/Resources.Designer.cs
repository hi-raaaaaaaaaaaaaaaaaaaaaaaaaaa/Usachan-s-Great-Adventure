﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Game.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Game.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.Drawing.Bitmap Death {
            get {
                object obj = ResourceManager.GetObject("Death", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.Drawing.Bitmap Enemy {
            get {
                object obj = ResourceManager.GetObject("Enemy", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.Drawing.Bitmap Gameover {
            get {
                object obj = ResourceManager.GetObject("Gameover", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.Drawing.Bitmap Player {
            get {
                object obj = ResourceManager.GetObject("Player", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.Drawing.Bitmap Shot {
            get {
                object obj = ResourceManager.GetObject("Shot", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.Drawing.Bitmap Shot_en {
            get {
                object obj = ResourceManager.GetObject("Shot_en", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   System.IO.MemoryStream に類似した型 System.IO.UnmanagedMemoryStream のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.IO.UnmanagedMemoryStream snddeath {
            get {
                return ResourceManager.GetStream("snddeath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   System.IO.MemoryStream に類似した型 System.IO.UnmanagedMemoryStream のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.IO.UnmanagedMemoryStream sndgameover {
            get {
                return ResourceManager.GetStream("sndgameover", resourceCulture);
            }
        }
        
        /// <summary>
        ///   System.IO.MemoryStream に類似した型 System.IO.UnmanagedMemoryStream のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.IO.UnmanagedMemoryStream sndhit {
            get {
                return ResourceManager.GetStream("sndhit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   System.IO.MemoryStream に類似した型 System.IO.UnmanagedMemoryStream のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.IO.UnmanagedMemoryStream sndkill {
            get {
                return ResourceManager.GetStream("sndkill", resourceCulture);
            }
        }
        
        /// <summary>
        ///   System.IO.MemoryStream に類似した型 System.IO.UnmanagedMemoryStream のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.IO.UnmanagedMemoryStream sndshot {
            get {
                return ResourceManager.GetStream("sndshot", resourceCulture);
            }
        }
    }
}