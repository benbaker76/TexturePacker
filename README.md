# Texture Packer

## About
Texture Packer is a program that packs images into textures for use in OpenGL and DirectX applications. It creates a data file which gives the name and coordinates of each image in the texture. These are also known as a texture atlas. It uses a rectangle packing algorithm based on the pseudo code in the [article by Jim Scott](http://www.blackpawn.com/texts/lightmaps/default.html).

## Features
- Supports .png, .bmp, .jpg, .gif and .tif image formats
- Recursively process a directory of images
- Output to text or xml format
- Supports multiple texture output
- Supports spacing between texture and alpha or colored backgrounds
- Use size limits to fit more images or resize images
- Supports Nearest Neighbor or Bilinear filtering
- Supports resizing to nearest power of 2 and maintaining aspect ratio
- Includes Sprite Sheet Slicer tool for cutting up sprite sheets into separate image files

## Screenshots
![](/images/texpack.png)

## Release Notes
| Date |Description |
|---|---|
| 15-08-2012 | v1.6.1 - Faster image file size reading |
| 29-01-2012 | v1.5 - Added support for multiple folders and post-processing using a batch file |
| 13-06-2011 | v1.4 - Added Sprite Sheet Slicer tool |
| 11-11-2010 | v1.3 - Improved speed and sorting |
| 20-06-2010 | v1.2 - Added support for loading and saving settings |
| 01-05-2010 | v1.1 - Added pcx support &amp; Fill Spacing option |
| 14-02-2010 | v1.0 - First Release |
