﻿namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices


/// Traces for polar subplots, using layout.polar as anchors.
///
/// The following trace types are compatible with polar subplots via the polar attribute:
///
/// - scatter-like trace types: scatterpolar and scatterpolargl, which can be used to draw individual markers, curves and filled areas (i.e. radar or spider charts)
///
/// - barpolar: useful for wind roses and other polar bar charts

type TracePolar(traceTypeName) =

    inherit Trace(traceTypeName)

    ///initializes a trace of type "scatterpolar" applying the given trace styling function
    static member initScatterPolar(applyStyle: TracePolar -> TracePolar) =
        TracePolar("scatterpolar") |> applyStyle

    ///initializes a trace of type "scatterpolargl" applying the given trace styling function
    static member initScatterPolarGL(applyStyle: TracePolar -> TracePolar) =
        TracePolar("scatterpolargl") |> applyStyle

    ///initializes a trace of type "barpolar" applying the given trace styling function
    static member initBarPolar(applyStyle: TracePolar -> TracePolar) = TracePolar("barpolar") |> applyStyle

/// Create various functions for applying polar chart styles to traces
type TracePolarStyle() =

    static member SetPolar([<Optional; DefaultParameterValue(null)>] ?PolarId: StyleParam.SubPlotId) =
        (fun (trace: TracePolar) ->

            PolarId |> DynObj.setValueOptBy trace "subplot" StyleParam.SubPlotId.toString

            trace)

    /// <summary>
    /// Create a function that applies the styles of a polar scatter plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points and the trace is not stacked then the default is "lines+markers". Otherwise, "lines".</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="R">Sets the radial coordinates</param>
    /// <param name="R0">Alternate to `r`. Builds a linear space of r coordinates. Use with `dr` where `r0` is the starting coordinate and `dr` the step.</param>
    /// <param name="DR">Sets the r coordinate step.</param>
    /// <param name="Theta">Sets the angular coordinates</param>
    /// <param name="Theta0">Alternate to `theta`. Builds a linear space of theta coordinates. Use with `dtheta` where `theta0` is the starting coordinate and `dtheta` the step.</param>
    /// <param name="DTheta">Sets the theta coordinate step. By default, the `dtheta` step equals the subplot's period divided by the length of the `r` coordinates.</param>
    /// <param name="ThetaUnit">Sets the unit of input "theta" values. Has an effect only when on "linear" angular axes.</param>
    /// <param name="Text">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
    /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="MultiTextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverText">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Subplot">Sets a reference between this trace's data coordinates and a polar subplot. If "polar" (the default value), the data refer to `layout.polar`. If "polar2", the data refer to `layout.polar2`, and so on.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="TextFont">Sets the text font of this trace.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="ClipOnAxis">Determines whether or not markers and text nodes are clipped about the subplot axes. To show markers and text nodes above axis lines and tick labels, make sure to set `xaxis.layer` and `yaxis.layer` to "below traces".</param>
    /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
    /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `fillcolor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
    /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="HoverOn">Do the hover effects highlight individual points (markers or line points) or do they highlight filled regions? If the fill is "toself" or "tonext" and there are no markers or text, then the default is "fills", otherwise it is "points".</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member ScatterPolar
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Mode: StyleParam.Mode,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?R: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?R0: IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DR: IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Theta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Theta0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DTheta: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?ThetaUnit: StyleParam.AngularUnit,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Subplot: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?ClipOnAxis: bool,
            [<Optional; DefaultParameterValue(null)>] ?ConnectGaps: bool,
            [<Optional; DefaultParameterValue(null)>] ?Fill: StyleParam.Fill,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverOn: string,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: seq<#IConvertible>
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Mode |> DynObj.setValueOptBy trace "mode" StyleParam.Mode.convert
            Ids |> DynObj.setValueOpt trace "ids"
            R |> DynObj.setValueOpt trace "r"
            R0 |> DynObj.setValueOpt trace "r0"
            DR |> DynObj.setValueOpt trace "dr"
            Theta |> DynObj.setValueOpt trace "theta"
            Theta0 |> DynObj.setValueOpt trace "theta0"
            DTheta |> DynObj.setValueOpt trace "dtheta"
            ThetaUnit |> DynObj.setValueOptBy trace "thetaunit" StyleParam.AngularUnit.convert
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Subplot |> DynObj.setValueOptBy trace "subplot" StyleParam.SubPlotId.convert
            Marker |> DynObj.setValueOpt trace "marker"
            Line |> DynObj.setValueOpt trace "line"
            TextFont |> DynObj.setValueOpt trace "textfont"
            SelectedPoints |> DynObj.setValueOpt trace "selectedpoints"
            Selected |> DynObj.setValueOpt trace "selected"
            Unselected |> DynObj.setValueOpt trace "unselected"
            ClipOnAxis |> DynObj.setValueOpt trace "cliponaxis"
            ConnectGaps |> DynObj.setValueOpt trace "connectgaps"
            Fill |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.convert
            FillColor |> DynObj.setValueOpt trace "fillcolor"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            HoverOn |> DynObj.setValueOpt trace "hoveron"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)

    /// <summary>
    /// Create a function that applies the styles of a polar bar plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Base">Sets where the bar base is drawn (in radial axis units). In "stack" barmode, traces that set "base" will be excluded and drawn in "overlay" mode instead.</param>
    /// <param name="R">Sets the radial coordinates</param>
    /// <param name="R0">Alternate to `r`. Builds a linear space of r coordinates. Use with `dr` where `r0` is the starting coordinate and `dr` the step.</param>
    /// <param name="DR">Sets the r coordinate step.</param>
    /// <param name="Theta">Sets the angular coordinates</param>
    /// <param name="Theta0">Alternate to `theta`. Builds a linear space of theta coordinates. Use with `dtheta` where `theta0` is the starting coordinate and `dtheta` the step.</param>
    /// <param name="DTheta">Sets the theta coordinate step. By default, the `dtheta` step equals the subplot's period divided by the length of the `r` coordinates.</param>
    /// <param name="ThetaUnit">Sets the unit of input "theta" values. Has an effect only when on "linear" angular axes.</param>
    /// <param name="Width">Sets the bar angular width (in "thetaunit" units).</param>
    /// <param name="MultiWidth">Sets the bar angular width (in "thetaunit" units).</param>
    /// <param name="Offset">Shifts the angular position where the bar is drawn (in "thetatunit" units).</param>
    /// <param name="MultiOffset">Shifts the angular position where the bar is drawn (in "thetatunit" units).</param>
    /// <param name="Text">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Subplot">Sets a reference between this trace's data coordinates and a polar subplot. If "polar" (the default value), the data refer to `layout.polar`. If "polar2", the data refer to `layout.polar2`, and so on.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member BarPolar
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Base: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?R: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?R0: IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DR: IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Theta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Theta0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DTheta: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?ThetaUnit: StyleParam.AngularUnit,
            [<Optional; DefaultParameterValue(null)>] ?Width: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Offset: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiOffset: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Subplot: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: seq<#IConvertible>
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Ids |> DynObj.setValueOpt trace "ids"
            Base |> DynObj.setValueOpt trace "base"
            R |> DynObj.setValueOpt trace "r"
            R0 |> DynObj.setValueOpt trace "r0"
            DR |> DynObj.setValueOpt trace "dr"
            Theta |> DynObj.setValueOpt trace "theta"
            Theta0 |> DynObj.setValueOpt trace "theta0"
            DTheta |> DynObj.setValueOpt trace "dtheta"
            ThetaUnit |> DynObj.setValueOptBy trace "thetaunit" StyleParam.AngularUnit.convert
            (Width, MultiWidth) |> DynObj.setSingleOrMultiOpt trace "width"
            (Offset, MultiOffset) |> DynObj.setSingleOrMultiOpt trace "offset"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Subplot |> DynObj.setValueOptBy trace "subplot" StyleParam.SubPlotId.convert
            Marker |> DynObj.setValueOpt trace "marker"
            SelectedPoints |> DynObj.setValueOpt trace "selectedpoints"
            Selected |> DynObj.setValueOpt trace "selected"
            Unselected |> DynObj.setValueOpt trace "unselected"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)
