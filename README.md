# ARIdentificationApp

Project state: Project finished.

Target operating system: Android 8.0 (Oreo)

Used versions:
  - Unity 2018.2.10f1
  - Vuforia 7.5.20
  - ARCore 1.4.

Purpose: App which should be able to recognize a predefined 3D object, overload a virtual object and showing information to parts of the object.

End state: three projects:
  - GroundplaneTests: An app using only a Ground Plane to place the virtual model, no recognition used.
  - ARIdentificationApp: A proof of concept to test different recognition techniques (Model Target, QR Code, with and without Ground Planes)
  - SparepartIdentifier: The final app using QRCode as recognition technique.
  
  Nice to know: 
  - The imported CAD-model from MTG (Vuforia Model Target Generator) is stored under /Assets/Model and a prefab which can be reused.
  - Apps using a QR Code for recognition will have the image stored under /Assets/Editor/Vuforia/ImageTargetTextures.
  - Customized fonts, images and materials can be found under /Assets/Design/
  - The folder called "Build" contains the different build files used for building on a Samsung Galaxy Tab S4.
