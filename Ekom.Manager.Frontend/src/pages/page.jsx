import React from 'react';
import PropTypes from 'prop-types';
import Helmet from 'react-helmet';

const Page = ({ title, link, meta, children }) => {
  return (
    <main>
      <Helmet title={title} link={link} meta={meta} />
      { children }
    </main>
  );
};

Page.propTypes = {
  title: PropTypes.string,
  link: PropTypes.array,
  meta: PropTypes.array
};

export default Page;