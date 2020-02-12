# Zeroer

When using virtual machines with expanding virtual disk drives, they only store data which is not zero. Over the space of time, although the virtual drives are not full, the data is still there, making the virtual drive physically larger than is required.

The process to reduce the expanding virtual disk drive, is first to overwrite all free space with zeros, and then shrink the drive. 
This process can take extremely long if the virtual drive is large.

To speed up this process, you can create a large file filled with zeros, which means there is significantly less free space to overwrite with zeros.

If you start running out of space on the virtual machine, simply reduce the size of the zeros file and then you are ok.
