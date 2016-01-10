using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using Optional.Serialization;
using Optional.Tests.Dtos;

namespace Optional.Tests
{
    [TestFixture]
    public class OptionalSerializationTests
    {
        [Test]
        public void WhenSerializingWithOptionalJsonConverterAndOptionalIsSet()
        {
            var documentDto = new DocumentDto()
            {
                Id = 1,
                Name = "test1",
                Revisions = new Optional<IEnumerable<string>>(
                    new List<string>()
                    {
                        "test"
                    }
                )
            };

            var json = JsonConvert.SerializeObject(
                documentDto,
                Formatting.Indented,
                new OptionalJsonConverter());

            Assert.AreEqual(json, "{\r\n  \"Id\": 1,\r\n  \"Name\": \"test1\",\r\n  \"Revisions\": [\r\n    \"test\"\r\n  ]\r\n}");
        }

        [Test]
        public void WhenSerializingWithOptionalJsonConverterAndOptionalIsNotSet()
        {
            var documentDto = new DocumentDto()
            {
                Id = 1,
                Name = "test1"
            };

            var json = JsonConvert.SerializeObject(
                documentDto,
                Formatting.Indented,
                new OptionalJsonConverter());

            Assert.AreEqual(json, "{\r\n  \"Id\": 1,\r\n  \"Name\": \"test1\",\r\n  \"Revisions\": null\r\n}");
        }

        [Test]
        public void WhenSerializingWithOptionalContractResolverAndOptionalIsSet()
        {
            var documentDto = new DocumentDto()
            {
                Id = 1,
                Name = "test1",
                Revisions = new Optional<IEnumerable<string>>(
                    new List<string>()
                    {
                        "test"
                    }
                )
            };

            var json = JsonConvert.SerializeObject(
                documentDto,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new OptionalContractResolver()
                });

            Assert.AreEqual(json, "{\r\n  \"Id\": 1,\r\n  \"Name\": \"test1\",\r\n  \"Revisions\": [\r\n    \"test\"\r\n  ]\r\n}");
        }

        [Test]
        public void WhenSerializingWithOptionalContractResolverAndOptionalIsNotSet()
        {
            var documentDto = new DocumentDto()
            {
                Id = 1,
                Name = "test2"
            };

            var json = JsonConvert.SerializeObject(
                documentDto,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new OptionalContractResolver()
                });

            Assert.AreEqual(json, "{\r\n  \"Id\": 1,\r\n  \"Name\": \"test2\"\r\n}");
        }

    }
}