/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Services
{
    public interface IConsumer<T>
    {
        void HandleEvent(T eventMessage);
    }
}
