﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MessagePack.Tests
{
    public class ToJsonTest
    {
        string JsonConvert(string json)
        {
            return MessagePackSerializer.ToJson(MessagePackSerializer.FromJson(json));
        }

        [Theory]
        [InlineData("null")]
        [InlineData("true")]
        [InlineData("false")]
        [InlineData("4141.431242")]
        [InlineData("414")]
        [InlineData(@"{""hoge"":100,""huga"":null,""nano"":false}")]
        [InlineData(@"[1,20,false,true,3424.432]")]
        public void SimpleToJson(string json)
        {
            JsonConvert(json).Is(json);
        }

        [Fact]
        public void ComplexToJson()
        {
            var json = @"{""reservations"":[{""instances"":[{""type"":""small"",""state"":{""name"":""running""},""tags"":[{""Key"":""Name"",""Values"":[""Web""]},{""Key"":""version"",""Values"":[""1""]}]},{""type"":""large"",""state"":{""name"":""stopped""},""tags"":[{""Key"":""Name"",""Values"":[""Web""]},{""Key"":""version"",""Values"":[""1""]}]}]},{""instances"":[{""type"":""medium"",""state"":{""name"":""terminated""},""tags"":[{""Key"":""Name"",""Values"":[""Web""]},{""Key"":""version"",""Values"":[""1""]}]},{""type"":""xlarge"",""state"":{""name"":""running""},""tags"":[{""Key"":""Name"",""Values"":[""DB""]},{""Key"":""version"",""Values"":[""1""]}]}]}]}";
            JsonConvert(json).Is(json);
        }
    }
}
