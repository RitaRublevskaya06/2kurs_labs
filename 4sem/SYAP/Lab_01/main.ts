// Задача 1
function createPhoneNumber(numbers: number[]): string {
    if (numbers.length !== 10) {
      throw new Error("Array must contain exactly 10 numbers.");
    }
    const numStr = numbers.join('');
    return `(${numStr.slice(0, 3)}) ${numStr.slice(3, 6)}-${numStr.slice(6)}`;
  }
  
  console.log(createPhoneNumber([1, 2, 3, 4, 5, 6, 7, 8, 9, 0])); // "(123) 456-7890"
  
  
  // Задача 2
  class Challenge {
    static solution(number: number): number {
      if (number <= 0) return 0;
      let sum = 0;
      for (let i = 1; i < number; i++) {
        if (i % 3 === 0 || i % 5 === 0) {
          sum += i;
        }
      }
      return sum;
    }
  }
  
  console.log(Challenge.solution(10)); // 23
  
  
  // Задача 3
  function rotateArray(nums: number[], k: number): number[] {
    k = k % nums.length; // Обработка k больше длины массива
    const rotated = nums.splice(nums.length - k);
    return rotated.concat(nums);
  }
  
  console.log(rotateArray([1, 2, 3, 4, 5, 6, 7], 3)); // [5, 6, 7, 1, 2, 3, 4]
  
  
  // Задача 4
  function findMedianSortedArrays(nums1: number[], nums2: number[]): number {
    const merged = [...nums1, ...nums2].sort((a, b) => a - b);
    const mid = Math.floor(merged.length / 2);
    if (merged.length % 2 === 0) {
      return (merged[mid - 1] + merged[mid]) / 2;
    } else {
      return merged[mid];
    }
  }
  
  console.log(findMedianSortedArrays([1, 3], [2])); // 2
  console.log(findMedianSortedArrays([1, 2], [3, 4])); // 2.5
  
  
  