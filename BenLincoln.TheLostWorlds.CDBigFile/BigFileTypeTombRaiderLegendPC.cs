using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using BF = BenLincoln.TheLostWorlds.CDBigFile;

namespace BenLincoln.TheLostWorlds.CDBigFile
{
    public class BigFileTypeTombRaiderLegendPC : BigFileType
    {
        public BigFileTypeTombRaiderLegendPC()
            : base()
        {
            Name = "TRLPC";
            Description = "Tomb Raider: Legend (PC)";
            MasterIndexType = IndexType.TRLPC;
            HashLookupTable = new FlatFileHashLookupTable("TRL", Path.Combine(mDLLPath, "Hashes-TRL.txt"));
            FileTypes = new FileType[]
            {
                BF.FileType.FromType(BF.FileType.FILE_TYPE_RAWImage),
                BF.FileType.FromType(BF.FileType.FILE_TYPE_MUL_Defiance),
                new FileType()
            };
        }
    }
}
