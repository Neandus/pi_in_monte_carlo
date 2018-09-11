# pi_in_monte_carlo
Calculating π by Monte-Carlo method enhanced with learning WPF and MVVM pattern.

MVVM responsibility.

View:
- drawing all generated points (for circle and for square)
- display calculated value of pi
- pass request to generate more points (1 or 10, depends on the button pressed)

ViewModel:
- calls "generate more points" method of model
- expose generated point lists and pi value to view

Model:
- generates random points
	- generates new point 
	- assign point to circle list and to square list (or rather points outside the circle list)
- calculates new pi value

Links:
https://www.markwithall.com/programming/2013/03/01/worlds-simplest-csharp-wpf-mvvm-example.html
https://iamtimcorey.com/design-patterns-ocp/
https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel
https://en.wikipedia.org/wiki/Monte_Carlo_method
https://social.msdn.microsoft.com/Forums/sqlserver/en-US/83376231-1d93-47b5-acc3-2fa51f151c1f/how-to-add-children-to-a-canvas-dynamically-in-mvvm?forum=wpf


Next step:
Attached Behaviour in WPF, resizing option.

Objectives:
 - Resize circle, square and recalculate points when windows size was changed.

View:
- pass request that window was resized (new r value)

ViewModel:
- calls "resize" method of model

Model:
- resize or better recalculates all points relative to new size od the window
	- recalculate resize factor with use of new and old r value
	- store new r value
	
Links:
https://social.msdn.microsoft.com/Forums/vstudio/en-US/8fa56178-4a16-4ec2-84b2-9b5c845b1648/get-a-views-actual-height-and-width?forum=wpf
https://www.codeproject.com/Articles/28959/Introduction-to-Attached-Behaviors-in-WPF
