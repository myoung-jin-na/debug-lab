// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Runtime.Intrinsics.X86;

namespace deep_copy
{
    class Program
    {
        static void Main(string[] args)
        {
            S2F42 s2f42 = new S2F42("S2F42", false, "Host Command Acknowledge (HCA) - RCMD 21 Reply", 1);
            s2f42.Body.HCACK = 1;
            s2f42.Body.aCmdParams.Enqueue(new RCMD_ACK { CP_NAME = "Lot ID"     , CP_ACK = 1 });
            s2f42.Body.aCmdParams.Enqueue(new RCMD_ACK { CP_NAME = "PPID"       , CP_ACK = 1 });
            s2f42.Body.aCmdParams.Enqueue(new RCMD_ACK { CP_NAME = "QTY"        , CP_ACK = 1 });
            s2f42.Body.aCmdParams.Enqueue(new RCMD_ACK { CP_NAME = "PART_NUMBER", CP_ACK = 1 });
            s2f42.Body.aCmdParams.Enqueue(new RCMD_ACK { CP_NAME = "TEMP"       , CP_ACK = 1 });
            s2f42.Body.aCmdParams.Enqueue(new RCMD_ACK { CP_NAME = "TEST_MODE"  , CP_ACK = 1 });
            s2f42.Body.aCmdParams.Enqueue(new RCMD_ACK { CP_NAME = "TEST_TIME"  , CP_ACK = 1 });
            s2f42.Body.aCmdParams.Enqueue(new RCMD_ACK { CP_NAME = "SOCKET_MAP" , CP_ACK = 1 });

            s2f42.PrintMe();
            Console.WriteLine("\n");

            var s2f42_copy = (S2F42)s2f42.Clone();
            s2f42_copy.Body.HCACK = 99;

            // 깊은 복사를 하지 않으면 copy와 원본이 같은 값을 갖게 된다.
            s2f42.PrintMe();
            Console.WriteLine("\n");
            s2f42_copy.PrintMe();

            // ICloneable의 Clone을 사용하지 않고 복사 생성자도 만들어 지지 않았다면
            // copy와 원본이 같은 값을 갖게 된다.
            var s2f42_copy2 = new S2F42(s2f42);
            s2f42_copy2.Body.HCACK = 999;
            s2f42.PrintMe();
            Console.WriteLine("\n");
            s2f42_copy2.PrintMe();

        }

        class RCMD_PARAM
        {
            public string CP_NAME { get; set; }
            public string CP_VALUE { get; set; }
        }
        class RCMD_ACK
        {
            public string CP_NAME { get; set; }
            public int CP_ACK { get; set; }
        }

        class Secs2_Head
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int S { get; set; }
            public int F { get; set; }
            public bool W { get; set; }
            public string Description { get; set; }
            public Int32 Systembyte { get; set; }

            public Secs2_Head() { }
            public Secs2_Head(Secs2_Head other)
            {
                Id          = other.Id;
                S           = other.S;
                F           = other.S;
                W           = other.W;
                Description = other.Description;
                Systembyte  = other.Systembyte;
            }
            public Secs2_Head Clone()
            {
                return (Secs2_Head)this.MemberwiseClone(); // 얕은 복사로 충분
            }

            public virtual void PrintMe()
            {
                Console.WriteLine($"Name={Name}, S={S}, F={F}, WBit={W}, {Description}");
            }
        }
        abstract class Secs2_Body
        {
            public abstract void PrintMe();
            public abstract object Clone();
        }

        class S2F42_Body : Secs2_Body, ICloneable
        {
            public UInt16 HCACK { get; set; }
            public Queue<RCMD_ACK> aCmdParams;

            public S2F42_Body()
            {
                aCmdParams = new Queue<RCMD_ACK>();
            }
            public S2F42_Body(S2F42_Body other)
            {
                HCACK = other.HCACK;
                aCmdParams = new Queue<RCMD_ACK>(other.aCmdParams.Select(p => new RCMD_ACK
                {
                    CP_NAME = p.CP_NAME,
                    CP_ACK = p.CP_ACK
                }));
            }
            public override object Clone()
            {
                var cloneBody = new S2F42_Body(this);
                return cloneBody;
            }
            public override void PrintMe()
            {
                Console.WriteLine($"HCACK={HCACK}");
                foreach(var e in aCmdParams)
                {
                    Console.WriteLine($"CP_NAME={e.CP_NAME.PadRight(15)}, CP_ACK={e.CP_ACK.ToString().PadLeft(5)}");
                }
            }
        }

        class Secs2<TBody> where TBody : Secs2_Body
        {
            public Secs2_Head Head { get; set; }
            public TBody Body { get; set; }

            public virtual void PrintMe()
            {
                Head.PrintMe();
                Body.PrintMe();
            }
        }

        class S2F42 : Secs2<S2F42_Body>, ICloneable
        {
            public S2F42(string Name, bool wait, string Description, int Systembyte)
            {
                Head = new Secs2_Head()
                {
                    Id          = 2,
                    Name        = Name,
                    S           = 2,
                    F           = 42,
                    W           = wait,
                    Description = Description
                 };

                Body = new S2F42_Body();
            }

            public S2F42(S2F42 other)
            {
                Head = new Secs2_Head(other.Head);
                Body = new S2F42_Body(other.Body);                
            }

            public object Clone()
            {                
                var clone = new S2F42(this);
                return clone;
            }
        }
    }
}

