// SPDX-FileCopyrightText: 2024 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

using GLTFast.Vertex;
using NUnit.Framework;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace GLTFast.Tests
{
    class VertexBufferTexCoordsTests
    {
        [Test]
        public void SparseTexCoords()
        {
            var v = new VertexBufferTexCoords<VTexCoord1>(1, 1, null);

            var handles = new NativeArray<JobHandle>(1, Allocator.Temp);
            var success = v.ScheduleVertexUVJobs(
                0,
                new[] { GltfBufferMock.sparseAccessorIndex },
                handles,
                new GltfBufferMock()
                );
            Assert.IsFalse(success);
            v.Dispose();
            handles.Dispose();
        }
    }
}
