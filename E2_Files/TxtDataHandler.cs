using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2_Files
{
    public struct TxtFileData
    {
        public string path;
        public int rComponent;
        public int gComponent;
        public int bComponent;

        public TxtFileData(string path, int rComponent, int gComponent, int bComponent)
        {
            this.path = path;
            this.rComponent = rComponent;
            this.gComponent = gComponent;
            this.bComponent = bComponent;
        }
    }

    class TxtDataHandler
    {
        public class TxtDataWriter : BinaryWriter
        {
            public TxtDataWriter(Stream str) : base(str) { }

            public void Write(TxtFileData data)
            {
                base.Write(data.path);
                base.Write(data.rComponent);
                base.Write(data.gComponent);
                base.Write(data.bComponent);
            }
        }

        public class TxtDataReader : BinaryReader
        {
            public TxtDataReader(Stream str) : base(str) { }

            public TxtFileData ReadTxtFileData()
            {
                TxtFileData data;
                data.path = base.ReadString();
                data.rComponent = base.ReadInt32();
                data.gComponent = base.ReadInt32();
                data.bComponent = base.ReadInt32();
                return data;
            }
        }
    }
}
