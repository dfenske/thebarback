import * as React from 'react';
import { RouteComponentProps } from 'react-router';


export class Home extends React.Component<RouteComponentProps<{}>, {}> {
  public render() {
    return (
      <div>
        <div className="background">
          <div className="layer">
            <div className="float-top snippet flow-text brown-text text-lighten-4">Not sure what to drink? Tell us what you're in the mood for and we'll point you towards some delicious recipes.</div>
            <div className="float-bottom"><a href="#content" className="scroll-down-button"><i className="large material-icons">keyboard_arrow_down</i></a></div>
          </div>
        </div>
        <div id="content" className="container">
          <div className="row">
            <div className="col s12 l4">
              <div className="card">
                <div className="card-image one">
                  <div className="card-layer">
                    <a href="/search"><span className="card-title right">What do you have?</span></a>
                  </div>
                </div>
                <div className="card-content">
                  <p>Tell us what's in your bar and we will suggest some cocktails that don't require putting on pants to make.</p>
                </div>
                <div className="card-action">
                  <a href="/search">Search</a>
                </div>
              </div>
            </div>
            <div className="col s12 l4">
              <div className="card">
                <div className="card-image two">
                  <div className="card-layer">
                    <a href="/search"><span className="card-title right">Build a drink</span></a>
                  </div>
                </div>
                <div className="card-content">
                  <p>Start from the ground up - tell us your base liquor, your mixers, and any other special touches that you are craving.</p>
                </div>
                <div className="card-action">
                  <a href="/search">Build a drink</a>
                </div>
              </div>
            </div>
            <div className="col s12 l4">
              <div className="card ">
                <div className="card-image three">
                  <div className="card-layer">
                    <a href="/surprise"><span className="card-title white-text">Surprise me!</span></a>
                  </div>
                </div>
                <div className="card-content">
                  <p>Feeling adventurous? We dare you to drink whatever shows up first...</p>
                </div>
                <div className="card-action">
                  <a href="/surprise">Surprise me!</a>
                </div>
              </div>
            </div>
          </div>
        </div >
      </div >
    );
  }
}

/**
<ul>
  <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
  <li><a href='https://facebook.github.io/react/'>React</a> and <a href='http://www.typescriptlang.org/'>TypeScript</a> for client-side code</li>
  <li><a href='https://webpack.github.io/'>Webpack</a> for building and bundling client-side resources</li>
  <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
</ul>
<p>To help you get started, we've also set up:</p>
<div className="container">
</div>
<ul>
  <li><strong>Client-side navigation</strong>. For example, click <em>Counter</em> then <em>Back</em> to return here.</li>
  <li><strong>Webpack dev middleware</strong>. In development mode, there's no need to run the <code>webpack</code> build tool. Your client-side resources are dynamically built on demand. Updates are available as soon as you modify any file.</li>
  <li><strong>Hot module replacement</strong>. In development mode, you don't even need to reload the page after making most changes. Within seconds of saving changes to files, rebuilt React components will be injected directly into your running application, preserving its live state.</li>
  <li><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and the <code>webpack</code> build tool produces minified static CSS and JavaScript files.</li>
</ul>
<h4>Going further</h4>
<p>
  For larger applications, or for server-side prerendering (i.e., for <em>isomorphic</em> or <em>universal</em> applications), you should consider using a Flux/Redux-like architecture.
      You can generate an ASP.NET Core application with React and Redux using <code>dotnet new reactredux</code> instead of using this template.
  </p>
**/