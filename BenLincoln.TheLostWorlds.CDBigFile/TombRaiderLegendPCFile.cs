// BenLincoln.TheLostWorlds.CDBigFile
// Copyright 2006-2018 Ben Lincoln
// http://www.thelostworlds.net/
//

// This file is part of BenLincoln.TheLostWorlds.CDBigFile.

// BenLincoln.TheLostWorlds.CDBigFile is free software: you can redistribute it and/or modify
// it under the terms of version 3 of the GNU General Public License as published by
// the Free Software Foundation.

// BenLincoln.TheLostWorlds.CDBigFile is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with BenLincoln.TheLostWorlds.CDBigFile (in the file LICENSE.txt).  
// If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BF = BenLincoln.TheLostWorlds.CDBigFile;
using BD = BenLincoln.Data;

namespace BenLincoln.TheLostWorlds.CDBigFile
{
    public class TombRaiderLegendPCFile : BF.File
    {
        public TombRaiderLegendPCFile(BF.BigFile parent, BF.Index parentIndex, uint[] rawIndexData, int hashNamePosition, int offsetPosition, int lengthPosition)
        {
            // Copied from File
            mNamePrefix = "";
            mNameSuffix = "";
            mParentBigFile = parent;
            // Modified for TRL PC
            long bigFileId = (rawIndexData[offsetPosition]) / 76800u;
            mBigFilePath = Path.ChangeExtension(mParentBigFile.Path, bigFileId.ToString().PadLeft(3, '0'));
            mBigFileSize = new FileInfo(mBigFilePath).Length;
            mParentIndex = parentIndex;
            mRawIndexData = rawIndexData;
            uint rawHash = rawIndexData[hashNamePosition];
            mHashedName = BD.HexConverter.ByteArrayToHexString(BD.BinaryConverter.UIntToByteArray(rawHash));
            // Modified for TRL PC
            mOffset = ((rawIndexData[offsetPosition]) % 76800) * 2048;
            mLength = (int)rawIndexData[lengthPosition];
            CheckFileDataForSanity();
            if (mIsValidReference)
            {
                GetHeaderData();
                mType = GetFileType();
                mCanBeReplaced = true;
            }
            else
            {
                mType = BF.FileType.FromType(BF.FileType.FILE_TYPE_Invalid);
            }
            GetNameComponents();
        }

        public TombRaiderLegendPCFile(BF.BigFile parent, BF.Index parentIndex, uint[] rawIndexData, string hashedName, int offsetPosition, int lengthPosition)
        {
            // Copied from File
            mParentBigFile = parent;
            // Modified for TRL PC
            long bigFileId = (rawIndexData[offsetPosition]) / 76800u;
            mBigFilePath = Path.ChangeExtension(mParentBigFile.Path, bigFileId.ToString().PadLeft(3, '0'));
            mBigFileSize = new FileInfo(mBigFilePath).Length;
            mParentIndex = parentIndex;
            mRawIndexData = rawIndexData;
            mHashedName = hashedName;
            // Modified for TRL PC
            mOffset = ((rawIndexData[offsetPosition]) % 76800) * 2048;
            mLength = (int)rawIndexData[lengthPosition];
            CheckFileDataForSanity();
            if (mIsValidReference)
            {
                GetHeaderData();
                mType = GetFileType();
                mCanBeReplaced = true;
            }
            else
            {
                mType = BF.FileType.FromType(BF.FileType.FILE_TYPE_Invalid);
            }
            GetNameComponents();
        }
    }
}
