﻿#region COPYRIGHT
/****************************************************************************
 *  Copyright (c) 2015 Fabio Ferretti <https://plus.google.com/+FabioFerretti3D>                 *
 *  This file is part of Sardauscan.                                        *
 *                                                                          *
 *  Sardauscan is free software: you can redistribute it and/or modify      *
 *  it under the terms of the GNU General Public License as published by    *
 *  the Free Software Foundation, either version 3 of the License, or       *
 *  (at your option) any later version.                                     *
 *                                                                          *
 *  Sardauscan is distributed in the hope that it will be useful,           *
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of          *
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the           *
 *  GNU General Public License for more details.                            *
 *                                                                          *
 *  You are not allowed to Sell in any form this code                       * 
 *  or any compiled version. This code is free and for free purpose only    *
 *                                                                          *
 *  You should have received a copy of the GNU General Public License       *
 *  along with Sardaukar.  If not, see <http://www.gnu.org/licenses/>       *
 ****************************************************************************
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Sardauscan.Gui.Controls;
using Sardauscan.Core;

namespace Sardauscan.Gui.CalibrationSteps
{
	/// <summary>
	/// Interface for a Calibration Step 
	/// </summary>
	public interface ICalibrationStepInfo 
	{
		/// <summary>
		/// Order id for visual order of the Clibration step button
		/// </summary>
		int OrderId { get; }
		/// <summary>
		/// Label of the Calibration Step button
		/// </summary>
		string Label { get; }
		/// <summary>
		/// Type of the Main Calibration step Control
		/// </summary>
		Type ControlType { get; }
	}
	/// <summary>
	/// Extention class For ICalibrationStepInfo
	/// </summary>
	public static class ICalibrationStepInfoExt 
	{
		/// <summary>
		/// Get the predefined Image for the button
		/// </summary>
		/// <param name="step"></param>
		/// <returns></returns>
		public static Image Image(this ICalibrationStepInfo  step)
		{
			Type stepControlType = step.ControlType;
			if(stepControlType == typeof(Manual))
					return global::Sardauscan.Properties.Resources.Tools;
			if(stepControlType == typeof(CorrectionMatrix))
					return global::Sardauscan.Properties.Resources.Magic;
			if(stepControlType == typeof(Dimention))
					return global::Sardauscan.Properties.Resources.Cube;
			return global::Sardauscan.Properties.Resources.Gears;
		}
		/// <summary>
		/// Create the Calibration Step info Control
		/// </summary>
		/// <param name="step"></param>
		/// <returns></returns>
		public static Control CreateControl(this ICalibrationStepInfo step)
		{
			try
			{
				object ctrl = Reflector.CreateInstance<object>(step.ControlType);
				if (ctrl!=null && ctrl is Control)
					return (Control)ctrl;
			}
			catch
			{
			}
				return new UnderConstruction();		 
		}
		 
	}
}
