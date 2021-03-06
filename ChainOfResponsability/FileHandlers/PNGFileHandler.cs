﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChainOfResponsability.Attribute;
using ChainOfResponsability.ChainOfResponsability;
using ChainOfResponsability.Helpers;

namespace ChainOfResponsability.FileHandlers
{
    public class PngFileHandler : IFileHandler
    {
        private IFileHandler _nextHandler;
        public void NextHandler(IFileHandler handler)
        {
            _nextHandler = handler;
        }

        public void HandleRequest(AddedFile file)
        {
            if (!file.Extension.Equals(StringEnum.GetStringValue(FileExtension.Png),
                StringComparison.CurrentCultureIgnoreCase))
            {
                if (_nextHandler == null)
                {
                    return;
                }
                _nextHandler.HandleRequest(file);
            }
            else
            {
                MoveFileHelper.ProcessFile(file);
            }
        }
    }
}
