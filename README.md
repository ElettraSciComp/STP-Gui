### SYRMEP Tomo Project (STP)

SYRMEP Tomo Project (STP) has been developed for the users of the SYRMEP beamline of the Elettra synchrotron facility (http://www.elettra.eu) to perform the digital image processing required by parallel beam propagation-based phase contrast CT experiments. The underlying idea is to let users perform post-beamtime optimization, fine tuning and/or additional tests with common hardware at their home institution. The software has been also developed for teaching and educational purposes. SYRMEP Tomo Project is available only for Windows 64-bit machines.

## References

If you use this software please cite: F. Brun et al., Enhanced and Flexible Software Tools for X-ray Computed Tomography at the Italian Synchrotron Radiation Facility Elettra (2015) Fundamenta Informaticae, 141 (2-3), pp. 233-243.

## Installation

No installation required. The software is portable. Decompress the .zip file and run the .exe. The .zip file can be downloaded from the Releases section of this GitHub repository (https://github.com/ElettraSciComp/STP-Gui/releases/).

## Software requirements

In most of the machines, the software runs without performing additional installations. In case of issues, consider that the following tools have to be installed in the user machine to correctly run the software:

* .NET Framework 4.0 (https://www.microsoft.com/en-us/download/details.aspx?id=17851)
* VC++ 2008 Redistributable x64 (https://www.microsoft.com/en-us/download/details.aspx?id=15336)
* VC++ 2010 Redistributable x64 (https://www.microsoft.com/en-us/download/details.aspx?id=14632) 
* VC++ Redistributable for Visual Studio 2015 x64 (https://www.microsoft.com/en-us/download/details.aspx?id=48145)

The installer for each of these tools is included into the "depend" folder within the .zip file of the SYRMEP Tomo Project.

## Hardware requirements

NVidia GPU CUDA-compliant card is required to exploit the features provided by the ASTRA toolbox (https://astra-toolbox.readthedocs.org). For an adequate model please refer to the ASTRA documentation. Without a CUDA-compliant GPU the software runs correctly but only CPU-based reconstruction algorithms are available.

## Credits

The software has been developed in collaboration with the University of Trieste (http://www.units.it) and CNR Nanotec (http://www.nanotec.cnr.it) and it is powered by the open source projects ASTRA-toolbox (https://astra-toolbox.readthedocs.org) and TomoPy (https://tomopy.readthedocs.org).

## License

The project is licensed under the GPL-v3 license.
